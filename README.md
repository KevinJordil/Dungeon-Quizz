# Dungeon Quizz

## Fonctionnement

### Main
Au départ, la scène Main est chargé, c'est ici qu'on va définir les variables et fonctions qui devront être disponible tout au long du jeu. Ensuite il charge automatique la première scène : **Menu**

### Menu
Le menu va appeler le provider qui s'occupe de récupérer les informations de l'API et de les transformer en objet C# sur l'url /quizzes. Ensuite pour chaque quizz, il va créer un bouton et aller chercher chaque quizz en ligne /quizzes/{id}, ce qui permet de ne plus faire aucun appel à l'API durant le reste de l'execution du jeu. Une fois que l'on clique sur le bouton d'un quizz, cela charge la scène **Quizz**

### Quizz
Le quizz va charger toutes les questions dans un tableau de questions "non-répondues", ensuite une question va être selectionnées aléatoirement dans ce tableau et affichée. Lors d'un clic sur une réponse, le script va contrôler si c'est la bonne réponse ou pas puis l'afficher. Cela permettra de définir le niveau (Easy ou Hard) du Jeu et charger la scène **Game**

### Game
Le jeu commence par charger le game manager et le gestionnaire des sons. Ensuite le game manager va lancer le board manager qui va s'occuper de construire la carte du jeux (potions, enemies, murs, joueur, sortie). Une fois la carte créée, il est possible de jouer au jeu. Le but du jeux est d'atteindre la sortie (en haut à droite) sans épuiser votre nourriture. En prenant les potions vous recevrez 10 ou 20 unités de nourriture. Les enemies vous traqueront et s'ils vous touche, vous perderez 10 unités de nourriture. Si votre nourritures atteint 0, la partie est perdue. Si vous réussissez à atteindre la sortie, une nouvelle question vous sera proposez.
## Fichiers

Classes :
* **Answer** permet de transformer une réponse JSON en objet
* **Quizz** permet de transformer un quizz JSON en objet
* **Quizzes** permet de transformer un élément du list de quizzes JSON en objet
* **Question** permet de transformer une question JSON en objet
* **Enemy** permet de gérer les actions des enemies
* **Loader** permet d'initialiser le SoundManager et le GameManager
* **MovingObject** permet de gérer tous les objets qui peuvent bouger
* **Player** permet de gérer les actions du joueur
* **Wall** permet de gérer les murs cassables

Managers :
* **MainManager** est le manager principale
* **MenuManager** permet de gérer la scène menu
* **QuizzManager** permet de gérer la scène Quizz
* **GameManager** permet de gérer la scène Game
* **BoardManager** permet de gérer la creation du plateau de jeu
* **SoundManager** permet de gérer les sons

Autres :
* **Provider** s'occupe de faire les appels à l'API et de transformer le JSON en objet

## Tutoriels
* [Quizz in Unity](https://www.youtube.com/watch?v=g_Ff1SPhidg&list=PLPV2KyIb3jR7ucA2yo5pjvKY0cJmNTq2L)
* [Customize text (Textmesh Pro)](https://assetstore.unity.com/packages/essentials/beta-projects/textmesh-pro-84126)
* [Dynamique quizz bouton avec scroll](http://gregandaduck.blogspot.com/2015/07/unity-ui-dynamic-buttons-and-scroll-view.html)
* [2D Roguelike tutorial](https://unity3d.com/fr/learn/tutorials/s/2d-roguelike-tutorial)
* [Sprites set](https://0x72.itch.io/dungeontileset-ii)

## Auteurs
* Kévin
* Benjamin
