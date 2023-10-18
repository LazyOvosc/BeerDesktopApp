CREATE TABLE Beer (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    type VARCHAR(255),
    producer VARCHAR(255),
    description TEXT
);

CREATE TABLE Food (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    category VARCHAR(255),
    description TEXT
);

CREATE TABLE "User" (
    id SERIAL PRIMARY KEY,
    is_logined BOOLEAN,
    name VARCHAR(255),
    login VARCHAR(255),
    password VARCHAR(255),
    email VARCHAR(255)
);

CREATE TABLE Rating (
    id SERIAL PRIMARY KEY,
    id_beer INT REFERENCES Beer(id),
    id_food INT REFERENCES Food(id),
    rating REAL,
    id_user INT REFERENCES "User"(id)
);

CREATE TABLE Shops (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255)
);

CREATE TABLE ShopsSum (
    shop_id INT REFERENCES Shops(id),
    beer_id INT REFERENCES Beer(id),
    price NUMERIC,
    url VARCHAR(255),
    PRIMARY KEY (shop_id, beer_id)
);
