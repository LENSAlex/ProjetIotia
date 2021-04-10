var express = require("express");
var mysql = require('mysql');
var app = express();

const port = 3001;

// BDD--------------------
console.log('Get connection ...');
var conn = mysql.createConnection({
    database: 'ProjetIotia',
    host: "51.75.125.121",
    user: "iotia",
    password: "iotia"
});

conn.connect(function(err) {
    if (err)
        res.status(404).json({ ErrorConnection: 'Error bdd' });
    console.log("Connected!");
})



//------------------------------GET ----------------------------

//Batiment-----
app.get("/Batiment/CountInfo/Campus", (req, res) => {
    //Affciahe nb etage et nb salle par campus
    conn.query("select a.nom , nbetage , nbsalle from (select Site.nom, count(id_salle) as nbsalle from Site, Batiment, Etage, Salle where Site.id_site = Batiment.id_site and Batiment.id_batiment = Etage.id_batiment and Etage.id_etage = Salle.id_etage group by Site.nom) a, (select Site.nom, count(Etage.id_etage) as nbetage from Site, Batiment, Etage where Site.id_site = Batiment.id_site and Batiment.id_batiment = Etage.id_batiment group by Site.nom) b where a.nom = b.nom", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    })
})

//List des equipement
app.get("/Batiment/ListEquipement", (req, res) => {
    conn.query("select id_equipement , libelle , description from Equipement", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//List des sites
app.get("/Batiment/ListSite", (req, res) => {
    conn.query("select id_site , nom from Site", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//List des Batiment
app.get("/Batiment/ListBatiment", (req, res) => {
    conn.query("select id_batiment ,id_site , nom from Batiment", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})





//Personne------
app.get("/Personne/ListPromo", (req, res) => {

    //Affichage formation avec departement et duree
    conn.query("select F.nom , P.annee ,F.duree from Promotion P , Formation F , Departement D where P.id_formation = F.id_formation and D.id_departement = F.id_departement", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    })
})

app.get("/Personne/ListPersonne", (req, res) => {

    //Prof faisable aussi voir demain

    //Affichage formation avec departement et duree
    conn.query("select * from (select Personne.id_personne, num_ref, Personne.id_pers_type, password, email, telephone, sexe, nom, prenom, date_anniversaire, rfid, libelle, description from Personne, PersonneType where Personne.id_pers_type = PersonneType.id_pers_type) pers LEFT JOIN (select nom as NomFormation, Contenir.id_promotion, id_eleve from (select id_promotion, nom from Promotion, Formation where Promotion.id_formation = Formation.id_formation and (annee + duree) >= (SELECT YEAR(NOW()))) a, Contenir where a.id_promotion = Contenir.id_promotion) b on pers.id_personne = b.id_eleve", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})


//List des types de personne
app.get("/Personne/ListTypePersonne", (req, res) => {
    conn.query("select id_pers_type , libelle from PersonneType", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//List Promo
app.get("/Personne/ListPromo", (req, res) => {
    conn.query("select id_promotion , Formation.nom from Promotion , Formation where Promotion.id_formation = Formation.id_formation", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//List Salle pour eleve
app.get("/Personne/ListSalleEleve/:Id", (req, res) => {
    conn.query("select distinct P.id_personne,S.id_salle from Personne P , Contenir C , Promotion Po , Cours Cou , Salle S where P.id_personne = C.id_eleve AND C.id_promotion = Po.id_promotion AND Po.id_promotion = Cou.id_promotion AND Cou.id_salle = S.id_salle and P.id_personne = '" + req.params.Id + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//Selection Personne via nom , prenom , email
app.get("/Personne/GetIdEleve/:Nom/:Prenom/:Email", (req, res) => {
    var id;
    conn.query("select id_personne from Personne where nom = '" + req.params.Nom + "' and prenom = '" + req.params.Prenom + "' and email = '" + req.params.Email + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            result.forEach((result) => {
                id = result.id_personne;
            });
            conn.query("INSERT INTO `CasCovid`(`id_personne`, `date_declaration`) VALUES ('" + id + "',NOW())", function(err, result) {
                if (err)
                    res.status(400).json({ ErrorRequete: 'Requete invalid' });
                else {
                    res.status(200).json("Cas covid cree");
                }
            });
        }
    });
})


//Selection Personne via INE (unique normalement)
app.get("/Personne/GetIdEleve/:Ine", (req, res) => {
    var id;
    conn.query("select id_personne from Personne where num_ref = '" + req.params.Ine + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            result.forEach((result) => {
                id = result.id_personne;
            });
            conn.query("INSERT INTO `CasCovid`(`id_personne`, `date_declaration`) VALUES ('" + id + "',NOW())", function(err, result) {
                if (err)
                    res.status(400).json({ ErrorRequete: 'Requete invalid' });
                else {
                    res.status(200).json("Cas covid cree");
                }
            });
        }
    });
})



//Covid---------

app.get("/Covid/CasCovid", (req, res) => {
    //Affichage de toutes les personne qui ont le covid
    //Pb pas remplie la table
    conn.query("select P.nom , P.prenom , CC.date_declaration from Personne P , CasCovid CC where P.id_personne = CC.id_personne", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

app.get("/Covid/Count/CasCovid/Formation" , (req,res) =>
{
    conn.query("select F.nom , count(*) as NbCasCovid from CasCovid CC , Personne P , Contenir C , Promotion Po , Formation F    where     CC.id_personne = P.id_personne    and     P.id_personne = C.id_eleve    AND    Po.id_promotion = C.id_promotion    and     Po.id_formation = F.id_formation    group by F.nom" , function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})


app.get("/Covid/Count/CasCovid/Departement" , (req,res) =>
{
    conn.query("select D.name , count(*) as NbCasCovid from CasCovid CC , Personne P , Contenir C , Promotion Po , Formation F , Departement D    where     CC.id_personne = P.id_personne    and     P.id_personne = C.id_eleve    AND    Po.id_promotion = C.id_promotion    and     Po.id_formation = F.id_formation AND F.id_departement = D.id_departement group by D.name", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

app.get("/Covid/Count/CasCovid/Formation/:IdFormation" , (req,res) =>
{
    conn.query("select F.nom , count(*) as NbCasCovid from CasCovid CC , Personne P , Contenir C , Promotion Po , Formation F    where     CC.id_personne = P.id_personne    and     P.id_personne = C.id_eleve    AND    Po.id_promotion = C.id_promotion    and     Po.id_formation = F.id_formation  and F.id_formation='" + req.params.IdFormation + "'  group by F.nom", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})


app.get("/Covid/Count/CasCovid/Departement/:IdDepartement" , (req,res) =>
{
    conn.query("select D.name , count(*) as NbCasCovid from CasCovid CC , Personne P , Contenir C , Promotion Po , Formation F , Departement D   where     CC.id_personne = P.id_personne    and     P.id_personne = C.id_eleve    AND    Po.id_promotion = C.id_promotion    and     Po.id_formation = F.id_formation AND F.id_departement = D.id_departement and D.id_departement= '" + req.params.IdDepartement + "' group by D.name", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})


//Capteur-----
//List des ValueType
app.get("/Capteur/ListValueType" , (req,res) =>
{
    conn.query("SELECT `id_valuetype`, `libelle`, `unite` FROM `ValueType`", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//Liste des devices sans arduino et rasp pour dorian
app.get("/Capteur/ListDevice", (req, res) => {
    //List device sans rpi et arduino 
    conn.query("select id_devicetype , libelle_type from DeviceType where id_devicetype <> 1 and id_devicetype <> 2", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

// Get Capteur de la salle via search (Cherche les capteurs d'une salle via le numéro de salle)
app.get("/Capteur/Search/:NomSalle", (req, res) => {
    conn.query("select D.id_device ,B.libelle , B.adr_ip , B.description ,Ba.nom , S.id_etage from Box B , Salle S , Etage E , Batiment Ba , Device D where B.id_salle = S.id_salle and S.id_etage = E.id_etage AND E.id_batiment = Ba.id_batiment and B.id_box = D.id_box and S.nom = '" + req.params.NomSalle + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//Info de chaque Box Ip , Etage , batiment ...
app.get("/Capteur/Box/Info", (req, res) => {

    //List device sans rpi et arduino 
    conn.query("select c.id_salle , c.id_box ,c.libelle , c.adr_ip , c.description ,c.nom , c.id_etage , c.nom as NomSalle , COALESCE(PanneauSolaire,0) as PanneauSolaire , COALESCE(NbBouton,0) as NbBouton  from (select a.id_salle , a.id_box ,a.libelle , a.adr_ip , a.description ,a.nom , a.id_etage , a.nom as NomSalle , PanneauSolaire from (select B.id_salle , B.id_box ,B.libelle , B.adr_ip , B.description ,S.nom , S.id_etage , S.nom as NomSalle from Box B , Salle S , Etage E , Batiment Ba where B.id_salle = S.id_salle and S.id_etage = E.id_etage AND E.id_batiment = Ba.id_batiment)a LEFT JOIN (select S.id_salle , count(*) as PanneauSolaire from DeviceType DT , Device D , Box B , Salle S where DT.id_devicetype = D.id_device AND D.id_box = B.id_box AND B.id_salle = S.id_salle AND DT.id_devicetype = 17 group by S.id_salle) b on a.id_salle = b.id_salle) c LEFT JOIN (select S.id_salle , count(*) as NbBouton from Device D , Box B , Salle S where D.id_box = B.id_box AND B.id_salle = S.id_salle AND D.id_devicetype = 11 group by S.id_salle) d on c.id_salle = d.id_salle", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//All Capteur d une salle
app.get("/Capteur/ListCapteur/:Salle", (req, res) => {
    conn.query("select D.id_device , VT.libelle from ValueType VT , Device D , Box B , Salle S where D.id_valuetype = VT.id_valuetype AND D.id_box = B.id_box and B.id_salle = S.id_salle and S.nom = '" + req.params.Salle + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//Liste des devices sans arduino et rasp pour dorian
app.get("/Capteur/ListDevice/All", (req, res) => {

    //List device sans rpi et arduino 
    conn.query("select Device.id_devicetype as TypeCapteur , Box.id_box as IDBoxCapteur, DeviceType.id_devicetype, libelle_type from DeviceType, Box , Device where Box.id_devicetype = DeviceType.id_devicetype AND Box.id_box = Device.id_box and DeviceType.id_devicetype <> 1 and DeviceType.id_devicetype <> 2", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//List des capteurs (device)
app.get("/Capteur/ListCapteur", (req, res) => {

    conn.query("select D.id_device ,DT.libelle_type , B.libelle from DeviceType DT , Device D , Box B where DT.id_devicetype = D.id_devicetype and D.id_box = B.id_box", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})


//Affichage des salles comme ca pour avoir id_box
app.get("/Capteur/ListSalle" , (req,res) =>
{
    conn.query("select S.nom , B.id_box , B.id_salle from Box B , Salle S where B.id_salle = S.id_salle", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//Chercher les valeurs d une salle
app.get("/Capteur/Valeur/:IdSalle" , (req,res) =>
{
    conn.query("select H.valeur , VT.libelle , S.nom from Historique H , ValueType VT , Box B , Salle S where H.id_valuetype = VT.id_valuetype and H.id_box = B.id_box and B.id_salle = S.id_salle AND S.id_salle = '" + req.params.IdSalle + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//Chercher une valeur precise dans une salle garce a son type 
app.get("/Capteur/Valeur/:IdSalle/:IdValueType" , (req,res) =>
{
    conn.query("select H.valeur , VT.libelle , S.nom from Historique H , ValueType VT , Box B , Salle S where H.id_valuetype = VT.id_valuetype and H.id_box = B.id_box and B.id_salle = S.id_salle AND S.id_salle = '" + req.params.IdSalle + "' and H.id_valuetype = '" + req.params.IdValueType + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

//-----------------------------------PUT-----------------------------
app.put("/Alerte/IsPenurie/:IdEquipement/:IdSalle", (req, res) => {
    conn.query("UPDATE `Penurie` SET `is_penurie`=true,`date_maj`=NOW() WHERE id_equipement = '" + req.params.IdEquipement + "' and id_salle='" + req.params.IdSalle + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})

app.put("/Alerte/NotPenurie/:IdEquipement/:IdSalle", (req, res) => {
    conn.query("UPDATE `Penurie` SET `is_penurie`=false,`date_maj`=NOW() WHERE id_equipement = '" + req.params.IdEquipement + "' and id_salle='" + req.params.IdSalle + "'", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json(result);
            console.log(result);
        }
    });
})


//-----------------------------------POST--------------------------------

app.post("/Personne/Add/:NumRef/:IdPersType/:Password/:Email/:Tel/:Sexe/:Nom/:Prenom/:Birth/:IdPromo", (req, res) => {

    var idUser;
    var TypePers;

    //localhost:3001/Personne/Add/125/1/test/alex.@gmail.com/0607070705/F/LENS/AL/1908-08-11 01:00:00/1
    conn.query("INSERT INTO `Personne`(`num_ref`, `id_pers_type`, `password`, `email`, `telephone`, `sexe`, `nom`, `prenom`, `date_anniversaire`) VALUES ('" + req.params.NumRef + "','" + req.params.IdPersType + "', '" + req.params.Password + "' , '" + req.params.Email + "', '" + req.params.Tel + "' , '" + req.params.Sexe + "' , '" + req.params.Nom + "' , '" + req.params.Prenom + "' , '" + req.params.Birth + "')", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            // res.status(200).json("Personne Creer");
        }
    });

    //La je vais chercher la requete que je viens d envoyer pour avoir l id de l utilisateur cree
    conn.query("SELECT id_personne , id_pers_type from Personne order by id_personne DESC LIMIT 1", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            // res.status(200);
            result.forEach((result) => {
                idUser = result.id_personne;
                TypePers = result.id_pers_type
                console.log(idUser + "" + TypePers)
            });

            console.log("avant boucle" + idUser + "" + TypePers)

            //Que si eleve
            if (TypePers == 1) {
                console.log("dedans")
                    //La je vais chercher la requete que je viens d envoyer pour avoir l id de l utilisateur cree
                conn.query("INSERT INTO `Contenir`(`id_promotion`, `id_eleve`) VALUES ('" + req.params.IdPromo + "','" + idUser + "')", function(err, result) {
                    if (err)
                        res.status(400).json({ ErrorRequete: 'Requete invalid' });
                    else {
                        res.status(200).json("Etudiant integrer dans la table Contenir");
                    }
                });
            } else {
                res.status(200);
            }

        }
    });

})


//Envoie nouveau covid vers CasCovid
app.post("/Alerte/Covid/:IdPersonne", (req, res) => {

    conn.query("INSERT INTO `CasCovid`(`id_personne`, `date_declaration`) VALUES ('" + req.params.IdPersonne + "',NOW())", function(err, result) {
        if (err)
            res.status(400).json({ ErrorRequete: 'Requete invalid' });
        else {
            res.status(200).json("Cas covid cree");
        }
    });
})

app.listen(port, () => {
    // console.log(`Example app listening at http://localhost:${port}`)
    console.log('Server listen on port 3001')
})