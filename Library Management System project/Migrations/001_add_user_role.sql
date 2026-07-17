-- Adds role-based access to dbo.Users.
-- Existing rows (today's librarians) default to 'Staff'; promote one manually
-- to 'Admin' afterward, e.g.:
--   UPDATE dbo.Users SET role = 'Admin' WHERE username = '<your admin username>';

ALTER TABLE dbo.Users ADD role NVARCHAR(20) NOT NULL DEFAULT 'Staff';
