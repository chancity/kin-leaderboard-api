BEGIN
	SET @otype = NEW.operation_type;
	IF(@otype = 1 OR @otype = 2) THEN
		SET @epoch_time = NEW.epoch_time;
		SET @epoch_time_day = @epoch_time - MOD(@epoch_time,86400);
		SET @app_id = NEW.app_id;
		SET @sender = NEW.sender;
		SET @recipient = NEW.recipient;
		SET @amount = NEW.amount;
		
		SET @new_wallet_count = IF(@otype = 1, 1, 0);
		
		INSERT INTO app_metric (`epoch_time`, `app_id`, `new_wallet_count`, `operation_count`)
			VALUES (@epoch_time_day, @app_id, @new_wallet_count, 1)
		ON DUPLICATE KEY UPDATE new_wallet_count=new_wallet_count+@new_wallet_count, operation_count=operation_count+1;
			
		INSERT INTO app_metric (`epoch_time`, `app_id`, `new_wallet_count`, `operation_count`)
			VALUES (@epoch_time_day, 'aggregate', @new_wallet_count, 1)
		ON DUPLICATE KEY UPDATE new_wallet_count=new_wallet_count+@new_wallet_count, operation_count=operation_count+1;
		
		INSERT INTO user_wallet (`address`, `app_id`, `friendly_name`, `tx_count`, `tx_volume`, `first_seen`, `last_seen`)
		VALUES (@sender, @app_id, @sender, 1, @amount, @epoch_time_day, @epoch_time)
		ON DUPLICATE KEY UPDATE tx_count=tx_count+IF(@otype = 2, 1,0), tx_volume=tx_volume+IF(@otype = 2, @amount,0), last_seen=@epoch_time;
		
		INSERT INTO user_wallet (`address`, `app_id`, `friendly_name`, `tx_count`, `tx_volume`, `first_seen`, `last_seen`)
		VALUES (@recipient, @app_id, @recipient, 1, @amount, @epoch_time_day, @epoch_time)
		ON DUPLICATE KEY UPDATE tx_count=tx_count+IF(@otype = 2, 1,0), tx_volume=tx_volume+IF(@otype = 2, @amount,0), last_seen=@epoch_time;
		
		IF(@otype = 2) THEN
			SET @is_sender_app = (SELECT COUNT(*) FROM app_wallet WHERE app_id=@app_id AND address=@sender);
			SET @is_recipient_app = (SELECT COUNT(*) FROM app_wallet WHERE app_id=@app_id AND address=@recipient);
			SET @payment_type = 1;
			SET @payment_type = IF(@is_sender_app = 1 AND @is_recipient_app = 0, 2,@payment_type);
			SET @payment_type = IF(@is_recipient_app = 1 AND @is_sender_app = 0, 3, @payment_type);
			INSERT INTO app_payment (`app_id`, `payment_type`, `epoch_time`, `sender`, `recipient`, `amount`) VALUES (@app_id, @payment_type, @epoch_time, @sender, @recipient, @amount);
		END IF;
	END IF;
END