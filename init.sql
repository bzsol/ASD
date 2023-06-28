CREATE TABLE todos (
    id SERIAL PRIMARY KEY,            
    date TIMESTAMP,                   
    title VARCHAR(255),               
    description TEXT,                 
    level INTEGER                     
);
