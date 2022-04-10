CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS favorites(
  id INT NOT NULL primary key AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  accountId varchar(255) NOT NULL,
  recipeId INT NOT NULL,
  FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';
DROP TABLE favorites;
CREATE TABLE IF NOT EXISTS recipes(
  id INT NOT NULL primary key AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  creatorId VARCHAR(255) NOT NULL,
  title varchar(255),
  subTitle varchar(255),
  category VARCHAR(255),
  FOREIGN KEY (creatorId) REFERENCES accounts(id),
  picture varchar(255)
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS ingredients(
  id INT NOT NULL primary key AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255),
  quantity varchar(255),
  recipeId INT NOT NULL,
  FOREIGN KEY (recipeId) REFERENCES recipes(id)
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS steps(
  id INT NOT NULL primary key AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  stepOrder INT,
  body varchar(255),
  recipeId INT NOT NULL,
  FOREIGN KEY (recipeId) REFERENCES recipes(id)
) default charset utf8 COMMENT '';
SELECT
  *
FROM
  recipes;
SELECT
  r.*,
  a.*
FROM
  recipes r
  JOIN accounts a
WHERE
  a.id = r.creatorId;
INSERT INTO
  steps (stepNumber, body, recipeId, creatorId)
VALUES
  (3, "Put it down and walk away");
SELECT
  *
FROM
  ingredients;
INSERT INTO
  ingredients (name, quantity, recipeId, creatorId)
VALUES
  (
    'Cheddar',
    'a million lbs.',
    '1',
    "60d3560eceb6bbdfae38856"
  );
DELETE FROM
  ingredients;
SELECT
  i.*,
  r.*
FROM
  ingredients i
  JOIN recipes r
WHERE
  i.recipeId = r.id;
SELECT
  i.*,
  r.*,
  s.*
FROM
  recipes r
  JOIN ingredients i ON i.recipeId = r.id
  JOIN steps s ON s.recipeId = r.id
WHERE
  i.recipeId = r.id
  AND s.recipeId = r.id;
SELECT
  r.*,
  s.*
FROM
  recipes r
  JOIN steps s
WHERE
  s.recipeId = r.id;
SELECT
  *
FROM
  recipes;
SELECT
  *
FROM
  ingredients;
DELETE FROM
  ingredients
WHERE
  id = 4