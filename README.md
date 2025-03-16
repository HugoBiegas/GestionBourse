# GestionBourse

Application multi-plateforme de gestion de portefeuille boursier développée avec .NET MAUI.

## Description

GestionBourse est une application permettant aux utilisateurs de gérer des portefeuilles d'actions pour différents traders. L'application permet de suivre les achats et ventes d'actions, de visualiser les portefeuilles et de réaliser des transactions.

## Fonctionnalités

- **Gestion des traders**: Visualisation et sélection des traders disponibles
- **Gestion des actions**: Suivi des actions disponibles sur le marché
- **Transactions**:
  - Achat de nouvelles actions pour un trader
  - Vente d'actions détenues par un trader
- **Visualisation**:
  - Liste des actions possédées par un trader
  - Liste des actions disponibles à l'achat
  - Détails des transactions (quantité, prix d'achat)

## Technologies utilisées

- **.NET MAUI**: Framework d'interface utilisateur multi-plateforme
- **C#**: Langage de programmation principal
- **XAML**: Définition des interfaces utilisateur
- **SQLite**: Base de données locale (via le package sqlite-net-pcl)
- **Pattern Repository**: Architecture de gestion des données

## Plateformes supportées

- Android (API 21+)
- iOS (11.0+)
- macOS (via Catalyst 13.1+)
- Windows (10.0.17763.0+)

## Architecture du projet

### Structure

- **Models**: Définition des entités de données
  - `Action.cs`: Modèle pour les actions boursières
  - `Trader.cs`: Modèle pour les traders (investisseurs)
  - `Transaction.cs`: Modèle pour les transactions d'achat/vente
  - `TransactionTrader.cs`: Modèle de vue pour afficher les informations fusionnées
  
- **Repositories**: Gestion des accès aux données
  - `ActionRepository.cs`: Opérations CRUD pour les actions
  - `TraderRepository.cs`: Opérations CRUD pour les traders
  - `TransactionRepository.cs`: Opérations CRUD pour les transactions
  
- **Datas**: Gestion de la base de données
  - `Database.cs`: Initialisation de la base de données et données de démo

- **Pages**: Interfaces utilisateur
  - `MainPage.xaml`: Page principale affichant la liste des traders
  - `PageChoix.xaml`: Page de sélection d'opération (acheter/vendre)
  - `PageActionsNonPossedees.xaml`: Page d'achat de nouvelles actions
  - `PageTransactions.xaml`: Page listant les actions possédées
  - `PageVendreAction.xaml`: Page de vente d'une action

### Flux de navigation

1. L'utilisateur sélectionne un trader depuis la page principale
2. L'utilisateur choisit entre acheter ou vendre une action
3. Pour l'achat:
   - Affichage des actions non possédées
   - Saisie du prix et de la quantité
   - Validation de l'achat
4. Pour la vente:
   - Affichage des actions possédées
   - Sélection d'une action à vendre
   - Confirmation de la vente

## Base de données

Le projet utilise SQLite comme base de données locale avec les tables suivantes:
- **Trader**: Stockage des investisseurs
- **Action**: Stockage des actions disponibles
- **Transaction**: Enregistrement des transactions d'achat/vente

L'application pré-remplit la base de données avec des traders, des actions et des transactions de démonstration lors de la première exécution.

## Installation

1. Cloner le repository
2. Ouvrir la solution avec Visual Studio 2022
3. Restaurer les packages NuGet
4. Sélectionner la plateforme cible
5. Compiler et exécuter l'application

## Dépendances

- Microsoft.Maui.Controls
- Microsoft.Maui.Controls.Compatibility
- Microsoft.Extensions.Logging.Debug
- sqlite-net-pcl

## Prérequis de développement

- Visual Studio 2022 avec la charge de travail "Développement .NET MAUI"
- .NET 8.0 SDK
- Émulateurs Android/iOS ou appareils physiques pour le test

## Captures d'écran

*Les captures d'écran seront ajoutées ultérieurement.*

## Futures améliorations

- Ajout d'un système d'authentification
- Intégration d'une API pour les cours boursiers en temps réel
- Graphiques d'évolution des cours
- Calcul de la performance du portefeuille
- Ajout de nouveaux traders et actions directement depuis l'application
