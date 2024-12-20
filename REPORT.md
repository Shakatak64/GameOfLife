# Rapport de projet

![Class diagram](diagrams/classDiagram.svg)
Diagrammes de classes pour les ViewModels ajoutés

![Activity Diagram](diagrams/activityDiagram.svg)
Diagramme d'activités pour la recherche de "destination" d'un animal et la gestion du déplacement de cet animal


## Utilisation des principes Solid
* Open-closed principle : Notre code est constitué de classes pouvant être étendues (Exemple: étendre la classe Carnivore si on veut ajouter une espèce)
* Liskov Substitution Principle : Nous pouvons traiter les objets d'une classe dérivée comme étant des objets de la classe mère (Exemple: Tous les membres de "animal" ont une fonction "eat" mais elle est implémentée différement en fonction de l'animal)
