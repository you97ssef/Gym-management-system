CREATE TABLE groupes(
    id INT PRIMARY KEY,
    nom_groupe VARCHAR(255),
    description_groupe VARCHAR(1020),
);

CREATE TABLE membres(
    id INT PRIMARY KEY,
    nom_membre VARCHAR(255),
    prenom_membre VARCHAR(255),
    datenaissance_membre DATE,
    contact_membre VARCHAR(1020),
    datejointure_membre DATE,
    groupe INT FOREIGN KEY REFERENCES groupes
);

CREATE TABLE utilisateurs(
    nom_utilisateur VARCHAR(30) PRIMARY KEY,
    motdepasse_utilisateur VARCHAR(30)
);

CREATE TABLE payements(
    id INT PRIMARY KEY,
    date_payement DATE,
    montant_payement DECIMAL(15,2),
    description_payement VARCHAR(1020),
    membre INT FOREIGN KEY REFERENCES membres
);