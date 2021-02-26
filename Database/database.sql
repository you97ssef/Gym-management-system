CREATE TABLE groupes(
    id INT PRIMARY KEY,
    nom_groupe VARCHAR(255),
    description_groupe VARCHAR(1020),
)

CREATE TABLE personnes(
    id INT PRIMARY KEY,
    nom_personne VARCHAR(255),
    prenom_personne VARCHAR(255),
    age_personne INT,
    contact_personne VARCHAR(1020),
    datejointure_personne DATE,
    groupe INT FOREIGN KEY REFERENCES groupes
)

CREATE TABLE utilisateurs(
    nom_utilisateur VARCHAR(30),
    motdepasse_utilisateur VARCHAR(30)
)

CREATE TABLE payements(
    id INT PRIMARY KEY,
    date_payement DATE,
    montant_payement DECIMAL(15,2),
    description_payement VARCHAR(1020)
    personne INT FOREIGN KEY REFERENCES personnes
)