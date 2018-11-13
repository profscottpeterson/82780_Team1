# Method Lists for Game, Player, and Spot Classes (11/12/2018)

<h2>Game Class</h2>
<h4>Constructor(s)</h4>
<ul>
  <li>public Game(ImageList chanceImages, ImageList communityChestImages) - line 27</li>
</ul>
<h4>Properties</h4>
<ul>
  <li>public List<Spot> Board { get; } - line 59</li>
  <li>public List<Card> ChanceCards { get; } - line 64</li>
  <li>public List<Card> RandomizedChanceCards { get; } - line 69</li>
  <li>public List<Card> CommunityChestCards { get; } - line 74</li>
  <li>public List<Card> RandomizedCommunityChestCards { get; } - line 79</li>
  <li>public List<Player> Players { get; set; } - line 84</li>
  <li>public int FreeParkingTotal { get; set; } - line 89</li>
  <li>public bool RestartGame { get; set; } - line 94</li>
</ul>
<h4>Methods</h4>
<ul>
  <li>public void RollChecks(Player currentPlayer) - line 101</li>
  <li>public void CheckPassGo(Spot prevLocation, Spot currentLocation, Player currentPlayer) - line 172</li>
  <li>public void MovePlayerLocation(Player currentPlayer, int spacesForward) - line 187</li>
  <li>public void CheckPayRent(Player currentPlayer, Spot currentLocation) - line 207</li>
  <li>public bool ShowBuyPropertyButton(Player currentPlayer, Spot currentLocation) - line 314</li>
  <li>public void CheckPayTax(Player currentPlayer, Spot currentLocation) - line 335</li>
  <li>public void CheckGoToJail(Player currentPlayer, Spot currentLocation) - line 363</li>
  <li>public Spot GetSpotByName(string name) - line 377</li>
  <li>public void DrawCard(List<Card> pile, Player currentPlayer) - line 399</li>
  <li>public int ActivePlayers() - line 563</li>
  <li>public void PlayGetOutOfJailFreeCard(Player currentPlayer) - line 582</li>
  <li>public void MoveCardToBottomOfPile(Card top) - line 611</li>
  <li>public Player NextPlayer(Player currentPlayer) - line 630</li>
  <li>public void CheckIfPlayerHasEnoughMoney(Player player) - line 651</li>
  <li>public void Forfeit(Player player) - line 670</li>
  <li>public static List<Color> CheckIfEligibleForHouse(List<Spot> prop) - line 727</li>
  <li>public void RandomizedCards() - line 827</li>
  <li>public void InstantiateList() - line 876</li>
  <li>public void CreateCards(ImageList chanceImages, ImageList communityChestImages) - line 1008</li>
</ul>
<h4>Methods not used</h4>
<ul>
  <li>public List<Spot> GetListOfPlayersPropertiesWithHotel(Player currentPlayer) - line 1114</li>
  <li>public List<Spot> GetListOfPlayersPropertiesWithHouses(Player currentPlayer) - line 1142</li>
  <li>public List<Spot> GetListOfPlayersMortgageableProperties(Player currentPlayer) - line 1170</li>
  <li>public void PlayerBuysProperty(Player currentPlayer, Spot property) - line 1217</li>
  <li>public bool CheckChance(Player currentPlayer, Spot currentLocation) - line 1237</li>
  <li>public bool CheckCommunityChest(Player currentPlayer, Spot currentLocation) - line 1257</li>
  <li>public Spot GetSpotById(int id) - line 1276</li>
</ul>

<h2>Player Class</h2>
<h4>Constructor(s)</h4>
<ul>
  <li>public Player() - line 26</li>
</ul>
<h4>Properties</h4>
<ul>
  <li>public bool OnChanceCard { get; set; } - line 42</li>
  <li>public bool OnComCard { get; set; } - line 47</li>
  <li>public int PlayerId { get; set; } - line 52</li>
  <li>public string PlayerName { get; set; } - line 57</li>
  <li>public Spot CurrentLocation { get; set; } - line 62</li>
  <li>public int Money { get; set; } - line 67</li>
  <li>public bool InJail { get; set; } - line 72</li>
  <li>public int TurnsInJail { get; set; } - line 77</li>
  <li>public List<Card> GetOutOfJailFreeCards { get; set; } - line 82</li>
  <li>public bool IsAi { get; set; } - line 87</li>
  <li>public PictureBox PlayerPictureBox { get; set; } - line 92</li>
  <li>public bool IsActive { get; set; } - line 97</li>
</ul>
<h4>Methods</h4>
<ul>
  <li>public bool NeedMoreMoney() - line 103</li>
  <li>public List<Spot> GetPlayersPropertyList(List<Spot> board) - line 114</li>
  <li>public int TotalNetWorth(List<Spot> board) - line 139</li>
  <li>public void SendToJail(Spot jail) - line 177</li>
</ul>

<h2>Spot Class</h2>
<h4>Constructor(s)</h4>
<ul>
  <li>public Spot(int spotId, string spotName, SpotType type) - line 29</li>
  <li>public Spot(int spotId, string spotName, int rent) - line 60</li>
  <li>public Spot(int spotId, string spotName, SpotType type, int price, int rent) - line 93</li>
  <li>public Spot(int spotId, string spotName, Color color, int price, int rent, int rent1House,
               int rent2Houses, int rent3Houses, int rent4Houses, int rentHotel, int mortgage, 
               int houseCost, int hotelCost) - line 141</li>
  <li>public Spot() - line 180</li>
</ul>
<h4>Properties</h4>
<ul>
  <li>public int SpotId { get; } - line 187</li>
  <li>public string SpotName { get; } - line 192</li>
  <li>public SpotType Type { get; } - line 197</li>
  <li>public Color Color { get; } - line 202</li>
  <li>public int Price { get; } - line 207</li>
  <li>public int Rent { get; } - line 212</li>
  <li>public int Rent1House { get; } - line 217</li>
  <li>public int Rent2Houses { get; } - line 222</li>
  <li>public int Rent3Houses { get; } - line 227</li>
  <li>public int Rent4Houses { get; } - line 232</li>
  <li>public int RentHotel { get; } - line 237</li>
  <li>public int Mortgage { get; } - line 244</li>
  <li>public int HouseCost { get; } - line 249</li>
  <li>public int HotelCost { get; } - line 254</li>
  <li>public bool IsAvailable { get; set; } - line 259</li>
  <li>public bool IsMortgaged { get; set; } - line 264</li>
  <li>public int NumberOfHouses { get; set; } - line 269</li>
  <li>public bool HasHotel { get; set; } - line 274</li>
  <li>public Player Owner { get; set; } - line 279</li>
  <li>public PictureBox SpotBox { get; set; } - line 284</li>
</ul>
<h4>Methods</h4>
<ul>
  <li>public Spot FindNearestSpotOfGivenType(List<Spot> board, SpotType type) - line 292</li>
  <li>public int NumberPropertyTypeOwned(List<Spot> board) - line 325</li>
  <li>public int FindCurrentRentOfRailroad(List<Spot> board) - line 352</li>
  <li>public int FindRentOfUtility(List<Spot> board, Player p) - line 374</li>
  <li>public int FindRentOfRegularProperty(List<Spot> board) - line 413</li>
</ul>
