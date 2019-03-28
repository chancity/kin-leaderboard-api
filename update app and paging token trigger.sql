BEGIN
	SET @paging_token = NEW.paging_token;
	SET @app_id = NEW.app_id;
	SET @ctype  = NEW.cursor;
	SET @epoch_time = NEW.epoch_time;
	SET @epoch_time_day = @epoch_time - MOD(@epoch_time,86400);
		
	INSERT INTO app (`app_id`, `first_seen`, `last_seen`) VALUES
	(@app_id, @epoch_time_day, @epoch_time)
	ON DUPLICATE KEY UPDATE last_seen=@epoch_time;
	
	INSERT INTO app (`app_id`, `first_seen`, `last_seen`) VALUES
	('aggregate', @epoch_time_day, @epoch_time)
	ON DUPLICATE KEY UPDATE last_seen=@epoch_time;
	
	INSERT INTO paging_token (`cursor`,`value`) VALUES
	(@ctype, @paging_token)
	ON DUPLICATE KEY UPDATE value=@paging_token;
END