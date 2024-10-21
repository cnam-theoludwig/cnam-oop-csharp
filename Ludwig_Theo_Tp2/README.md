# TP n°2 : Héritages et interfaces

Vous avez voyagé à travers le temps jusqu'en 1975 grâce à une boîte de glace Häagen-Dazs motorisée inventée par le doc Emmet Brown. Vous tentez - pour des questions pécuniaires - d'inventer le Space Invaders AVANT son inventeur (qui va lui-même l'inventer en 1978), en utilisant la technologie C#.

Techniquement, et si vous êtes bons en maths, cela vous laisserait 3 ans pour finir tous mes TP, mais ne rêvez pas, vous n'aurez pas autant de temps.

Pour rappel :

- Nous avons créé ensemble les classes `Player`, `SpaceInvaders`, `Spaceship`, `Weapon`, `Armory`, ~~`Vegan`~~ et ~~`GlutenFree`~~ ;
- Un vaisseau contient jusqu'à 3 armes ;
- Un joueur possède un vaisseau par défaut ;
- Votre jeu SpaceInvaders doit actuellement permettre les actions suivantes :
  - Afficher l'armurerie ;
  - Permettre de créer un nouveau joueur ;
  - Afficher toutes les informations du vaisseau du joueur sélectionné ;
  - Changer les armes de ce vaisseau ;
  - ~~Monter des blancs en neige ;~~
  - ~~Appeler ma tante Ursule ;~~

## 0. Préquel

Ajouter les interfaces suivantes à votre projet :

- `IPlayer.cs`
- `ISpaceship.cs`
- `IWeapon.cs`

## 1. Mettre à jour la classe `Weapon`

Avoir des armes sur son vaisseau tuning c'est bien.

Avoir des armes tuning sur un vaisseau tuning, c'est mieux.

Suivez les conseils de Jacky pour savoir comment faire du tuning sur vos armes :

1. Ajouter un attribut temps de rechargement à l'arme `ReloadTime` (un, qui se calculera en nombre de tour).
2. Ajouter un compteur de tours `TimeBeforReload` qui est initialisé à la valeur du temps de rechargement à la création de l'arme. Ce compteur sera décrémenté à chaque tour. Il permettra de savoir si l'arme est utilisable ou si elle est entrain de recharger.

3) Ajouter une fonction qui simule un tir Shoot().
   - a. Si le compteur n'est pas à zéro alors elle ne peut pas tirer (dégâts = 0)
   - b. Si elle peut tirer (compteur = 0), renvoyer un nombre de dégâts compris entre les dégâts min et max de l'arme.
   - c. Le type d'arme est un modificateur de dégâts :
     - i. Si l'arme est de type direct alors elle a 1 chance sur 10 de rater sa cible (0 dégât) ;
     - ii. Une arme de type explosif multiplie le résultat et le temps de rechargement par 2, et a 1 chance sur 4 de rater ;
     - iii. Une arme de type guidée touche toujours, mais avec les dégâts minimums ;
4) Liste minimum des armes disponibles dans l'armurerie:

| Nom de l'arme | Type      | MinDamage | MaxDamage | ReloadTime |
| ------------- | --------- | --------- | --------- | ---------- |
| Laser         | Direct    | 2         | 3         | 2          |
| Hammer        | Explosive | 1         | 8         | 1.5        |
| Torpille      | Guided    | 3         | 3         | 2          |
| Mitrailleuse  | Direct    | 6         | 8         | 1          |
| EMG           | Explosive | 1         | 7         | 1.5        |
| Missile       | Guided    | 4         | 100       | 4          |

PS : les valeurs chiffrées peuvent être modifiées à votre guise.

PSS : Vous pouvez en ajouter d'autre.

## 2. La différentiation des Ennemis (héritages)

Votre banquier vous le dira mieux que moi : dans la vie, tout ce qui compte, c'est l'héritage. Vous avez été conçus pour que quelqu'un puisse vous léguer un héritage, et vous allez concevoir des gens à qui vous pourrez léguer un héritage à votre tour.

Bref, l'héritage c'est la vie. Alors faisons en sorte que notre vaisseau aussi puisse avoir des héritiers !

1. Rendre la classe `Spaceship` abstraite. (Noter la différence : il devient impossible d'instancier un vaisseau, mais sa manipulation reste possible.)
2. Ajouter une fonction `TakeDamages` qui va faire en sorte de repartir les points de dégât à la suite d'un tir réussi. Si un bouclier est présent, c'est lui qui absorbera en premier les dégâts et seulement ensuite les points de structure. La fonction prend en paramètre un nombre qui est le total de dégâts d'un tir.
3. Ajouter une fonction `ShootTarget(Spaceship target)` au vaisseau elle va lui permettre de tirer sur un vaisseau ennemi passé en paramètre.
4. Ajouter les classes filles `Dart`, `B-Wings`, `Rocinante` et `ViperMKII` héritant de la classe vaisseau.

Astuce : afin d'accéder aux attributs des classes parents, vous pouvez mettre leurs visibilités en protected.

### 2.a. Dart

Dart c'est un peu un vaisseau cool quoi, il se la joue pas trop, il fait sa vie, il kiff, il est bien quoi. Si c'était pas votre ennemi ça pourrait presque être votre pote, c'est dommage.

1. Ce chasseur possède les caractéristiques suivantes :

   - a. Structure : 10
   - b. Bouclier : 3
   - c. Arme : Un "Laser" au minimum

2. Un Dart ne tient pas compte du temps de chargement d'une arme de type "Direct" et peut utiliser ces armes à chaque tour.

### 2.b. B-Wings

B-Wings c'est la force brute. C'est le Carlos de la chanson française, c'est le Stéphane Bern de l'Histoire de la Couronne, que dis-je, c'est le Sylvester Stallone du 7ème art. Il va vous donner du fil à retordre !

1. Ce vaisseau lourd possède les caractéristiques suivantes :

   - a. Structure : 30
   - b. Bouclier : aucun
   - c. Arme : Un "Hammer" au minimum

2. Un B-Wings ne tient pas compte du temps de chargement d'une arme de type "Explosive" et peut utiliser ces armes à chaque tour.

### 2.c. Rocinante

Rocinante est toujours dans les bons coups. Prêt à tout pour se faire de la marge, il est du genre filou. Spécialiste du coup par derrière et de la lâcheté, ne vous fiez jamais à lui. Gardez le bien dans votre viseur.

1. Ce bombardier possède les caractéristiques suivantes :

   - a. Structure : 3
   - b. Bouclier : 5
   - c. Arme : Une "Torpille" au minimum

2. Le Rocinante est plus rapide et esquive beaucoup mieux les tirs. Il a deux fois moins de chance de se faire toucher qu'un vaisseau normal.

### 2.d. ViperMKII

Il faut bien pouvoir se défendre face à tous ces ennemis plus fourbes les uns que les autres ! Voici le vaisseau du joueur ... et oui, c'est une antiquité.

1. Un vaisseau ViperMKII possède les caractéristiques suivantes :

   - a. Structure : 10
   - b. Bouclier : 15
   - c. Arme : Mitrailleuse, EMG et Missile

2. Un ViperMKII utilise une seule des armes rechargée (avec un compteur de rechargement à zéro) par tour (si plusieurs armes disponible au même tour une seule peut servir). A vous de voir comment faire pour ne pas toujours utiliser la mitrailleuse !

## 3. Les aptitudes spéciales (Interfaces)

Ma grand-mère m'a toujours dit : « Tu pourrais au moins être sympa, si déjà t'es pas beau. »

Ce qui dans notre exercice pourrait se traduire par : « Tu pourrais au moins avoir des aptitudes spéciales, si déjà t'as une interface compliquée. »

1. Créer l'interface `IAbility` possédant une fonction `void UseAbility(List<Spaceship> spaceships)` qui prend en paramètre une liste de vaisseau.
2. Créer deux nouveaux ennemis, `Tardis` et `F-18`, héritant de la classe `Spaceship` et implémentant l'interface `IAbility`
3. Au début de chaque tour de jeu, avant que le premier vaisseau ne tire, chaque vaisseau qui a une aptitude spéciale l'utilise.

### 3.a. F-18

La légende veut que si l'on est percuté par ce vaisseau la dernière phrase que l'on entende est la suivante : "Salut les mecs c'est moi!"

1. Ce vaisseau kamikaze possède les caractéristiques suivantes :

   - a. Structure : 15
   - b. Bouclier : aucun
   - c. Arme : aucune

2. Un F-18 ne possède pas d'armes, mais s'il est au contact avec le vaisseau joueur, il explose et lui fait 10 points de dégâts. Exemple de liste: [Vaisseau ennemi, Vaisseau joueur, Vaisseau ennemi, Vaisseau ennemi, Vaisseau ennemi, Vaisseau ennemi]

Cela se traduit par : Le F-18 explose si il se trouve en position 0 ou 2.

### 3.b. Tardis

1. Ce téléporteur possède les caractéristiques suivantes :

   - a. Structure : 1
   - b. Bouclier : aucun
   - c. Arme : aucune

2. L'aptitude spéciale du Tardis est de déplacer un vaisseau au hasard et de le mettre à un autre endroit dans la liste, toujours au hasard.

## 4. Mettre à jour la classe `SpaceInvaders`

Bien, nous avons tuné nos armes, créé notre vaisseau allié, nos ennemis ... Il ne reste plus qu'à déclencher une magnifique guerre des étoiles !

Je sais pas vous, mais moi je pense que ce sera toujours plus fun à regarder que Star Wars Episode VII. Et y aura pas Kylo Ren pour venir chialer cette fois.

1. Ajouter une liste d'ennemis de type `Spaceship`.
2. Faire une fonction `Init()` qui peuple la liste d'ennemis avec un vaisseau de chaque type.
3. Créer une fonction qui représente un tour `PlayRound`.

   - a. Elle devra faire jouer chaque vaisseau l'un après l'autre dans l'ordre de la liste d'ennemis.
   - b. Tous les ennemis tirent sur le vaisseau du joueur.
   - c. Le joueur tire sur un vaisseau non détruit au hasard dans la liste d'ennemis. Il aura [1/nombre d'ennemis en vie] chances de tirer en premier [2/nombre d'ennemis en vie] chances de tirer en deuxième et ainsi de suite.
   - d. Chaque début de tour les vaisseaux ayant perdu des points de bouclier en regagne maximum 2.

4. Dans la fonction `Main()`, créer une routine comme suit : tant que le vaisseau du joueur n'est pas détruit et qu'il reste des vaisseaux ennemis, relancer un tour.
5. Afficher les informations pertinentes (attaque, dommage, destruction, etc.) dans la console afin de visualiser l'évolution de la partie.
6. Tester votre programme

## 5. Pour aller plus loin

Créer des tests unitaires pour s'assurer du bon fonctionnement de vos implémentations.
