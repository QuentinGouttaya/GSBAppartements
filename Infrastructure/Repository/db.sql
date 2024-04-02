CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE personne (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    prenom VARCHAR(35) NOT NULL,
    nom VARCHAR(35) NOT NULL,
    adresse VARCHAR(75) UNIQUE NOT NULL,
    ville VARCHAR(25),
    code_postal VARCHAR(5),
    tel VARCHAR(11)
);

CREATE TABLE client (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    id_personne UUID NOT NULL UNIQUE REFERENCES personne(id)
);

CREATE TABLE proprietaire (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    id_personne UUID NOT NULL UNIQUE REFERENCES personne(id)
);

CREATE TABLE arrondissement (
    id SERIAL PRIMARY KEY,
    libelle VARCHAR(25) NOT NULL
);

CREATE TABLE appartement (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    type_appart VARCHAR(50) NOT NULL,
    prix_loc DECIMAL(10,2) NOT NULL,
    prix_charge DECIMAL(10,2) NOT NULL,
    adresse VARCHAR(75) UNIQUE NOT NULL,
    ville VARCHAR(25),
    code_postal VARCHAR(5),
    etage VARCHAR(2),
    avec_ascenseur BOOLEAN NOT NULL,
    avec_preavis BOOLEAN NOT NULL,
    date_libre DATE,
    id_proprietaire UUID NOT NULL REFERENCES proprietaire(id),
    id_arrondissement INTEGER NOT NULL REFERENCES arrondissement(id)
);


CREATE TABLE locataire (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    id_personne UUID NOT NULL UNIQUE REFERENCES personne(id),
    rib VARCHAR(34) NOT NULL,
    id_appartement UUID REFERENCES appartement(id)
);

CREATE TABLE demande (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    id_client UUID NOT NULL REFERENCES client(id),
    id_appartement UUID UNIQUE NOT NULL REFERENCES appartement(id)
);


INSERT INTO arrondissement (libelle) VALUES ('Plateau Mont-Royal');
INSERT INTO arrondissement (libelle) VALUES ('Rosemont–La Petite-Patrie');
INSERT INTO arrondissement (libelle) VALUES ('Ville-Marie');

INSERT INTO personne (prenom, nom, adresse, ville, code_postal, tel) VALUES ('Jean', 'Dupont', '123 rue Saint-Denis', 'Montigny', '78000', '0606060606');
INSERT INTO personne (prenom, nom, adresse, ville, code_postal, tel) VALUES ('Marie', 'Lefebvre', '456 rue Sherbrooke', 'Paris', '75000', '0707070707');

INSERT INTO proprietaire (id_personne) VALUES ((SELECT id FROM personne WHERE nom = 'Dupont'));

INSERT INTO appartement (type_appart, prix_loc, prix_charge, adresse, ville, code_postal, etage, avec_ascenseur, avec_preavis, date_libre, id_proprietaire, id_arrondissement)
VALUES (
    'Studio',
    750,
    50,
    '123 rue Saint-Denis',
    'Montréal',
    '78000',
    '2',
    true,
    true,
    '2023-03-01',
    (SELECT id FROM proprietaire WHERE id_personne = (SELECT id FROM personne WHERE nom = 'Dupont')),
    (SELECT id FROM arrondissement WHERE libelle = 'Plateau Mont-Royal')
);

INSERT INTO locataire (id_personne, rib, id_appartement)
VALUES (
    (SELECT id FROM personne WHERE nom = 'Lefebvre'),
    '123456789012345678901234567890',
    (SELECT id FROM appartement WHERE adresse = '123 rue Saint-Denis')
);