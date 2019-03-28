BEGIN
	SET @app_id = NEW.app_id;
	SET @payment_type = NEW.payment_type;
	SET @epoch_time = NEW.epoch_time;
	SET @epoch_time_day = @epoch_time - MOD(@epoch_time,86400);
	SET @sender = NEW.sender;
	SET @recipient = NEW.recipient;
	SET @amount = NEW.amount;
	SET @unique_payment_count = (SELECT COUNT(*) FROM unique_payment WHERE app_id=@app_id AND epoch_time=@epoch_time_day AND sender=@sender AND recipient=@recipient);
	SET @spend_is_unique = IF(@payment_type = 3 AND @unique_payment_count = 0, 1, 0);
	SET @spend_counter = IF(@payment_type = 3, 1, 0);
	SET @spend_amount = IF(@payment_type = 3, @amount, 0);
	SET @earn_is_unique = IF(@payment_type = 2 AND @unique_payment_count = 0, 1, 0);
	SET @earn_counter = IF(@payment_type = 2, 1, 0);
	SET @earn_amount = IF(@payment_type = 2, @amount, 0);
	SET @p2p_is_unique = IF(@payment_type = 1 AND @unique_payment_count = 0, 1, 0);
	SET @p2p_counter = IF(@payment_type = 1, 1, 0);
	SET @p2p_amount = IF(@payment_type = 1, @amount, 0);

	INSERT INTO app_metric (`epoch_time`, `app_id`, `spend_unique_count`, `spend_count`, `spend_volume`, `earn_unique_count`, `earn_count`, `earn_volume`, `p2p_unique_count`, `p2p_count`, `p2p_volume`)
	VALUES (@epoch_time_day, @app_id, @spend_is_unique, @spend_counter, @spend_amount, @earn_is_unique, @earn_counter, @earn_amount, @p2p_is_unique, @p2p_counter, @p2p_amount)
	ON DUPLICATE KEY UPDATE spend_unique_count=spend_unique_count+@spend_is_unique, spend_count=spend_count+@spend_counter, spend_volume=spend_volume+@spend_amount,
							earn_unique_count=earn_unique_count+@earn_is_unique, earn_count=earn_count+@earn_counter, earn_volume=earn_volume+@earn_amount,
							p2p_unique_count=p2p_unique_count+@p2p_is_unique, p2p_count=p2p_count+@p2p_counter, p2p_volume=p2p_volume+@p2p_amount;
							
	INSERT INTO app_metric (`epoch_time`, `app_id`, `spend_unique_count`, `spend_count`, `spend_volume`, `earn_unique_count`, `earn_count`, `earn_volume`, `p2p_unique_count`, `p2p_count`, `p2p_volume`)
	VALUES (@epoch_time_day, 'aggregate', @spend_is_unique, @spend_counter, @spend_amount, @earn_is_unique, @earn_counter, @earn_amount, @p2p_is_unique, @p2p_counter, @p2p_amount)
	ON DUPLICATE KEY UPDATE spend_unique_count=spend_unique_count+@spend_is_unique, spend_count=spend_count+@spend_counter, spend_volume=spend_volume+@spend_amount,
							earn_unique_count=earn_unique_count+@earn_is_unique, earn_count=earn_count+@earn_counter, earn_volume=earn_volume+@earn_amount,
							p2p_unique_count=p2p_unique_count+@p2p_is_unique, p2p_count=p2p_count+@p2p_counter, p2p_volume=p2p_volume+@p2p_amount;
												
	INSERT IGNORE INTO unique_payment (`app_id`, `epoch_time`, `sender`, `recipient`) VALUES (@app_id, @epoch_time_day, @sender, @recipient);
END