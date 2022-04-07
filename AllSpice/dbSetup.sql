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
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts(id),
  picture varchar(255) COMMENT 'Recipe Picture',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update'
) default charset utf8;
CREATE TABLE IF NOT EXISTS ingredients(
  id INT NOT NULL AUTO_INCREMENT primary key,
  name TEXT NOT NULL,
  quantity TEXT NOT NULL,
  recipeId INT NOT NULL,
  FOREIGN KEY (recipeId) REFERENCES recipes(id)
) default charset utf8;
CREATE TABLE IF NOT EXISTS steps(
  id INT NOT NULL AUTO_INCREMENT primary key,
  stepNumber INT NOT NULL,
  body TEXT NOT NULL,
  recipeId INT NOT NULL,
  FOREIGN KEY (recipeId) REFERENCES recipes(id)
) default charset utf8;
CREATE TABLE IF NOT EXISTS favorites(
  accountId VARCHAR(255) NOT NULL,
  FOREIGN KEY (accountId) REFERENCES accounts(id),
  recipeId INT NOT NULL,
  FOREIGN KEY (recipeId) REFERENCES recipes(id)
) default charset utf8;