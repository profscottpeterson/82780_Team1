# 82780_Team1 - Game Class Method List (10/28/2018):
<h3>Constructor(s)</h3>
<ul>
  <li>public Game(ImageList chanceImages, ImageList communityChestImages) - line 26</li>
</ul>
<h3>Properties</h3>
<ul>
  <li>public List<Spot> Board { get; } - line 55</li>
  <li>public List<Card> ChanceCards { get; } - line 63</li>
  <li>public List<Card> RandomizedChanceCards { get; } - line 68</li>
  <li>public List<Card> CommunityChestCards { get; } - line 73</li>
  <li>public List<Card> RandomizedCommunityChestCards { get; } - line 78</li>
  <li>public List<Player> Players { get; set; } - line 83</li>
  <li>public int FreeParkingTotal { get; set; } - line 88</li>
  <li>public bool RestartGame { get; set; } - line 93</li>
</ul>
<h3>Methods</h3>
<ul>
  <li>public List<Spot> GetPlayersPropertyList(Player currentPlayer) - line 100</li>
  <li>public Spot FindNearestSpotOfGivenType(Spot currentLocation, SpotType type) - line 126</li>
  <li>public void RollChecks(Player currentPlayer) - line 159</li>
  <li>public void CheckPassGo(Spot prevLocation, Spot currentLocation, Player currentPlayer) - line 230</li>
  <li>public void MovePlayerLocation(Player currentPlayer, int spacesForward) - line 245</li>
  <li>public void CheckPayRent(Player currentPlayer, Spot currentLocation) - line 265</li>
  <li>public bool ShowBuyPropertyButton(Player currentPlayer, Spot currentLocation) - line 316</li>
  <li>public void CheckPayTax(Player currentPlayer, Spot currentLocation) - line 337</li>
  <li>public void CheckGoToJail(Player currentPlayer, Spot currentLocation) - line 365</li>
  <li>public bool CheckChance(Player currentPlayer, Spot currentLocation) - not used - line 380</li>
  <li>public bool CheckCommunityChest(Player currentPlayer, Spot currentLocation) - not used - line 400</li>
  <li>public void SendToJail(Player currentPlayer) - line 418</li>
  <li>public Spot GetSpotByName(string name) - line 432</li>
  <li>public Spot GetSpotById(int id) - not used - line 454</li>
  <li>public void DrawCard(List<Card> pile, Player currentPlayer) - line 476</li>
  <li>public int ActivePlayers() - line 640</li>
  <li>public void PlayGetOutOfJailFreeCard(Player currentPlayer) - line 659</li>
  <li>public void MoveCardToBottomOfPile(Card top) - line 688</li>
  <li>public List<Spot> GetListOfPlayersPropertiesWithHotel(Player currentPlayer) - not used - line 707</li>
  <li>public List<Spot> GetListOfPlayersPropertiesWithHouses(Player currentPlayer) - not used - line 735</li>
  <li>public List<Spot> GetListOfPlayersMortgageableProperties(Player currentPlayer) - not used - line 763</li>
  <li>public int FindCurrentRentOfRailroad(Spot railroad) - line 811</li>
  <li>public int NumberRailroadsOwned(Spot railroad) - line 830</li>
  <li>public int FindRentOfUtility(Spot utility) - line 857</li>
  <li>public bool BothUtilitiesOwned(Spot utility) - line 898</li>
  <li>public Player NextPlayer(Player currentPlayer) - line 924</li>
  <li>public void PlayerBuysProperty(Player currentPlayer, Spot property) - not used - line 941</li>
  <li>public int TotalNetWorth(Player currentPlayer) - line 960</li>
  <li>public void CheckIfPlayerHasEnoughMoney(Player player) - line 996</li>
  <li>public void Forfeit(Player player) - line 1015</li>
  <li>public List<Color> CheckIfEligibleForHouse(List<Spot> prop) - line 1070</li>
  <li>public void RandomizedCards() - line 1170</li>
  <li>public void InstantiateList() - line 1219</li>
  <li>public void CreateCards(ImageList chanceImages, ImageList communityChestImages) - line 1349</li>
</ul>
