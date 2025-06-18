namespace ScoreBoard.Models
{
    public static class InitBD
    {
        public static List<Joueur> joueurs = new List<Joueur>
        {
            new Joueur { Nom = "Dupont", Prenom = "Jean", Equipe = "AIGL", Telephone = "514-123-4567", Courriel = "jean.dupont@scoreboard.ca" },
            new Joueur { Nom = "Tremblay", Prenom = "Lucie", Equipe = "RNRD", Telephone = "450-987-6543", Courriel = "lucie.tremblay@scoreboard.ca" },
            new Joueur { Nom = "Gagnon", Prenom = "Alexandre", Equipe = "LION", Telephone = "819-345-6789", Courriel = "alexandre.gagnon@scoreboard.ca" },
            new Joueur { Nom = "Lapointe", Prenom = "Sophie", Equipe = "TIGR", Telephone = "418-765-4321", Courriel = "sophie.lapointe@scoreboard.ca" },
            new Joueur { Nom = "Nguyen", Prenom = "Kevin", Equipe = "EPRV", Telephone = "514-876-5432", Courriel = "kevin.nguyen@scoreboard.ca" }
        };

        public static void Initialiser(IApplicationBuilder applicationBuilder)
        {
            //Récupérer le contexte de la base de données à partir du service
            ScoresDBContext context = applicationBuilder.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<ScoresDBContext>();

            if (!context.Joueurs.Any())
            {   
                context.Joueurs.AddRange(joueurs);
                context.SaveChanges();
            }

            if (!context.Jeux.Any())
            {
                var joueurs = context.Joueurs.ToList(); // Récupère les ID des joueurs enregistrés

                var jeux = new List<Jeu>
                {
                    new Jeu { Nom = "The Legend of Zelda: Breath of the Wild", DateSortie = new DateTime(2017, 3, 3), Description = "Jeu d'action-aventure en monde ouvert", JoueurId = joueurs[0].Id, ScoreJoueur = 60, DateEnregistrement = DateTime.Now },
                    new Jeu { Nom = "Super Mario Odyssey", DateSortie = new DateTime(2017, 10, 27), Description = "Jeu de plateforme en monde ouvert", JoueurId = joueurs[0].Id, ScoreJoueur = 50, DateEnregistrement = DateTime.Now },
                    new Jeu { Nom = "Red Dead Redemption 2", DateSortie = new DateTime(2018, 10, 26), Description = "Jeu d'action-aventure dans le Far West", JoueurId = joueurs[0].Id, ScoreJoueur = 100, DateEnregistrement = DateTime.Now },
                    new Jeu { Nom = "Assassin's Creed Odyssey", DateSortie = new DateTime(2018, 10, 5), Description = "Jeu d'action-aventure dans la Grèce antique", JoueurId = joueurs[1].Id, ScoreJoueur = 100, DateEnregistrement = DateTime.Now },
                    new Jeu { Nom = "God of War", DateSortie = new DateTime(2018, 4, 20), Description = "Jeu d'action-aventure mythologie nordique", JoueurId = joueurs[1].Id, ScoreJoueur = 30, DateEnregistrement = DateTime.Now },
                    new Jeu { Nom = "Cyberpunk 2077", DateSortie = new DateTime(2020, 12, 10), Description = "Jeu de rôle futuriste", JoueurId = joueurs[2].Id, ScoreJoueur = 70, DateEnregistrement = DateTime.Now },
                    new Jeu { Nom = "The Last of Us Part II", DateSortie = new DateTime(2020, 6, 19), Description = "Survie post-apocalyptique", JoueurId = joueurs[3].Id, ScoreJoueur = 100, DateEnregistrement = DateTime.Now },
                    new Jeu { Nom = "Animal Crossing: New Horizons", DateSortie = new DateTime(2020, 3, 20), Description = "Simulation de vie", JoueurId = joueurs[3].Id, ScoreJoueur = 10, DateEnregistrement = DateTime.Now },
                    new Jeu { Nom = "Doom Eternal", DateSortie = new DateTime(2020, 3, 20), Description = "FPS frénétique", JoueurId = joueurs[3].Id, ScoreJoueur = 90, DateEnregistrement = DateTime.Now },
                    new Jeu { Nom = "Ghost of Tsushima", DateSortie = new DateTime(2020, 7, 17), Description = "Japon féodal", JoueurId = joueurs[4].Id, ScoreJoueur = 100, DateEnregistrement = DateTime.Now },
                    new Jeu { Nom = "Hades", DateSortie = new DateTime(2020, 9, 17), Description = "Roguelike mythologique", JoueurId = joueurs[4].Id, ScoreJoueur = 40, DateEnregistrement = DateTime.Now }
                };

                context.Jeux.AddRange(jeux);
                context.SaveChanges();
            }
        }
    }
}
