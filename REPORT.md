# Rapport de projet

![Class diagram](diagrams/classDiagram.svg)
Diagrammes de classes pour les ViewModels ajoutés

![Activity Diagram](diagrams/activityDiagram.svg)
Diagramme d'activités pour la recherche de "destination" d'un animal et la gestion du déplacement de cet animal

![Sequence Diagram](https://www.plantuml.com/plantuml/svg/TO_FQl905CNtUOg3g-zR56h1JHR5qA881g4KNLzdRdJg_0cJYS6txsHIjQ4j12QNypldt3jl0ldG6ftLyLL2rMG3ojss13MObAJiJbdfkgtYhdIIzMH45Wahh3AayxMgUE6y6IFhHMAkOhuamvlz1uimvfQRn7sNjNCrAkV198wuArbQyE4PHOvt9KvP4V-NcwyX1gKHELPMUAQ6az10kDO6zbcHl54ltPdlqykHnGcgmWg2B0xgpDWh7uu3aafp55A2qi6_eN-cCGNyupFx2vvc2Fq-_qUvgmhM1P3kioHh3Wp381lh94plZv-ve7QD2ihPmRrUHEyR6nTTKx1bV-WHPGE6jkbZQhilzigLiWo2vGwIAsfrk8NUJ8Eh-NbwidNK1BwoiolBLcPPDezFQ_Gd)
Diagramme de séquence effectuée à chaque tick pour les animaux


## Utilisation des principes Solid
* Open-closed principle : Notre code est constitué de classes pouvant être étendues. Nous avons utilisé l'héritage ce qui nous permet d'étendre les classes génériques. On peut rajouter d'autre espèces d'animaux ainsi que leurs comportements respectifs sans avoir à modifier le reste du code.
* Liskov Substitution Principle : Nous pouvons traiter les objets d'une classe dérivée comme étant des objets de la classe mère (Exemple: Tous les membres de "animal" ont une fonction "eat" mais elle est implémentée différement en fonction de l'animal. C'est pareil pour la fonction "Tick" partagé par tous les gameObject, elle est appelée dans la boucle principale du programme mais chaque object réagira différement)
