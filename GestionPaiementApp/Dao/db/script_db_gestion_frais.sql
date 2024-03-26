 drop schema gestion_frais_academique_db;
 
Create database gestion_frais_academique_db;

use gestion_frais_academique_db;

create table if not exists gestion_frais_academique_db_info(
	param varchar(30) not null,
    valeur mediumtext not null,
    primary key(param)
);

insert into gestion_frais_academique_db_info
values ('creator','Argile Groupe'), 
	   ('creation_year','2023'), 
       ('creation_country','Democratic Republic of Congo'), 
       ('dbname', 'road_trip_agency_db');

create table if not exists user (
    id varchar(32),
    role enum('TOUT','FRAIS','INSCRIPTION', 'PARAMETRE', 'PARAMETRE_INSCRIPTION', 'PARAMETRE_FRAIS') default 'TOUT',
   	nom varchar(25),
	prenom varchar(25),
    username varchar(30) not null,
	`type` enum('ADMIN', 'USER') not null,
    email varchar(100) not null,
    passwd varchar(32) not null,
    m_salt varchar(32) not null,
    etat enum('FONCTIONNEL', 'BLOQUE', 'CONNECTE'),
    constraint pk_user PRIMARY KEY (id),
    constraint username_unique unique(username asc),
    constraint email_unique unique(email asc)
);

insert into user
values('0837f6bfb23948dbb80c3e9fbdf15fc4', 'TOUT', 'sysadmin', 'sysadmin', 'sysadmin', 'ADMIN', '', 'uXX8EDvhhzxiTuAp6VSVBrqd:18', '2iLCkgiFi3Fez5scGXVXKwoLTVihAMMo', 'FONCTIONNEL');

create table if not exists etudiant
(
	id varchar(32),
    matricule varchar(20),
	nom varchar(25),
	postnom varchar(25),
	prenom varchar(25),
	sexe enum('M', 'F') default 'M',
	telephone varchar(14),
	adresse text,
    constraint pk_etudiant primary key(id)
);

create table if not exists etudiant_empreinte 
(
	id varchar(32),
	etudiant_id varchar(32),
    empreinte_image mediumblob,
    empreinte_template mediumblob,
    size int, 
    finger enum('LL','LR','LM','LI','LT','RT','RI','RM','RR','RL'),
	constraint pk_etudiant_empreinte primary key(id),
    constraint fk_etudiant_empreinte_etudiant foreign key(etudiant_id) references etudiant(id) on update cascade
);

create table if not exists annee_academique
(
	id varchar(32),
    annee varchar(9),
    date_ouverture date,
    date_cloture date,
    constraint pk_annee_academique primary key(id),
	constraint annee_unique unique(annee asc)
);
create table if not exists faculte
(
	id varchar(32),
	nom varchar(200),
	constraint pk_faculte primary key(id),
    constraint faculte_unique unique(nom asc)
);

create table if not exists departement 
(
	id varchar(32),
	faculte_id varchar(32),
	nom varchar(200),
	constraint pk_departement primary key(id),
    constraint fk_departement_faculte foreign key(faculte_id) references faculte(id) on update cascade
);

create table if not exists niveau
(
	id varchar(32),
	nom varchar(10),
	ordre int,
    constraint pk_niveau primary key(id),
    constraint niveau_unique unique(nom asc)
 );
 
create table if not exists promotion
(
	id varchar(32),
	niveau_id varchar(32),
	departement_id varchar(32),
	filiere varchar(200),
	constraint pk_promotion primary key(id),
    constraint fk_promotion_niveau foreign key(niveau_id) references niveau(id) on update cascade,
	constraint fk_promotion_departement foreign key(departement_id) references departement(id) on update cascade
);

create table if not exists inscription
(
	id varchar(32),
	etudiant_id varchar(32),
	promotion_id varchar(32),
    annee_id varchar(32),
	vacation enum('MATIN','MIDI','SOIR') default 'MATIN',
	photo mediumtext,
	constraint pk_inscription primary key(id),
	constraint etudiant_annee_promotion_unique unique(etudiant_id, annee_id, promotion_id),
    constraint fk_inscription_etudiant foreign key(etudiant_id) references etudiant(id) on update cascade,
	constraint fk_inscription_promotion foreign key(promotion_id) references promotion(id) on update cascade,
    constraint fk_inscription_annee foreign key(annee_id) references annee_academique(id) on update cascade
);

create table if not exists prevision 
(
	id varchar(32),
	annee_id  varchar(32),
	niveau_id varchar(32),
	date date,
	nombre_tranche int,
	montant decimal(18, 2),
	constraint pk_prevision primary key(id),
	constraint fk_prevision_niveau foreign key(niveau_id) references niveau(id) on update cascade,
	constraint fk_prevision_annee foreign key(annee_id) references annee_academique(id) on update cascade
);

create table if not exists tranche 
(
	id varchar(32),
	prevision_id varchar(32),
    numero int,
	montant decimal(18, 2),
	constraint pk_tranche primary key(id),
	constraint fk_tranche_prevision foreign key(prevision_id) references prevision(id) on update cascade
);

create table if not exists paiement
(
	id varchar(32),
	inscription_id varchar(32),
    type enum('TRANCHE', 'PREVISION') default 'TRANCHE',
    mode_id varchar(32), /*tranche_id ou previson_id*/
	est_paye_totalite tinyint(1),
	date datetime, 
	montant decimal(18, 2),
	constraint pk_paiement primary key(id),
	constraint fk_paiement_inscription foreign key(inscription_id) references inscription(id) on update cascade
);

delimiter %
drop procedure if exists sp_get_info_paiement%
create procedure sp_get_info_paiement(v_inscription_id varchar(32), v_niveau_id varchar(32), v_annee_id varchar(32))
begin
   declare v_type varchar(10);
   
   select type into v_type from paiement P 
   inner join inscription I 
   on P.inscription_id = I.id
   where inscription_id = v_inscription_id and annee_id = v_annee_id
   order by date desc
   limit 1
   ;
   
   if v_type = 'TRANCHE' then
		select ifnull(P.montant, 0) paiement, T.numero, T.montant, 'TRANCHE' modalite 
		from tranche T inner join prevision PV
		on T.prevision_id = PV.id
		left join 
		(
			select sum(montant) montant, mode_id, inscription_id  from paiement
			where type = 'TRANCHE' and inscription_id = v_inscription_id
			group by mode_id, inscription_id
		)P
		on P.mode_id = T.id
		where PV.niveau_id = v_niveau_id and PV.annee_id = v_annee_id
        order by T.numero asc
        ;

	else 
     	select ifnull(P.montant, 0) paiement, 1 numero, PV.montant, 'PREVISION' modalite  from prevision PV
		left join 
		(
			select sum(montant) montant, mode_id, inscription_id  from paiement
			where type = 'PREVISION' and inscription_id = v_inscription_id
			group by mode_id, inscription_id
		)P
		on P.mode_id = PV.id
		where PV.niveau_id = v_niveau_id and PV.annee_id = v_annee_id;
	end if;
end%
  