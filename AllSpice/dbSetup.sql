CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS recipes(
  id INT NOT NULL AUTO_INCREMENT primary key,
  title TEXT NOT NULL,
  category TEXT NOT NULL,
  subtitle VARCHAR(255) NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  picture varchar(255) COMMENT 'Recipe Picture',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  FOREIGN KEY (creatorId) REFERENCES accounts(id)
) default charset utf8;
CREATE TABLE IF NOT EXISTS ingredients(
  id INT NOT NULL AUTO_INCREMENT primary key,
  name TEXT NOT NULL,
  quantity TEXT NOT NULL,
  recipeId INT NOT NULL,
  FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
) default charset utf8;
CREATE TABLE IF NOT EXISTS steps(
  id INT NOT NULL AUTO_INCREMENT primary key,
  stepNumber INT NOT NULL,
  body TEXT NOT NULL,
  recipeId INT NOT NULL,
  FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
) default charset utf8;
CREATE TABLE IF NOT EXISTS favorites(
  id INT NOT NULL AUTO_INCREMENT primary key,
  accountId VARCHAR(255) NOT NULL,
  recipeId INT NOT NULL,
  FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
) default charset utf8;
SELECT
  r.*,
  a.*
FROM
  recipes r
  JOIN accounts a
WHERE
  a.id = r.creatorId;
INSERT INTO
  recipes (title, category, subtitle, creatorId, picture)
VALUES
  (
    'Food',
    'dessert',
    'cheddar chocolate suprise',
    '60d3560eceb6bbdfae388576',
    'https://thiscatdoesnotexist.com'
  );
INSERT INTO
  accounts (id, email, picture)
VALUES
  (
    '60d3560eceb6bbdfae388576',
    'bigboi@bingbong.com',
    'https://thiscatdoesnotexist.com'
  );