// See https://aka.ms/new-console-template for more information
using LinqFaroShuffle;

Console.WriteLine("Hello, World!");

var deck = from s in Suits()
           from r in Ranks()
           select new {Suits = s, Ranks = r };

Console.WriteLine("\nStarting deck:");
foreach (var card in deck)
{
    Console.WriteLine(card);
}

var topHalf = deck.Take(deck.Count() / 2);
var bottomHalf = deck.Skip(deck.Count() / 2);
var shuffledDeck = topHalf.InterleaveCards(bottomHalf);

Console.WriteLine("\nFaro shuffled deck:");
foreach (var card in shuffledDeck)
{
    Console.WriteLine(card);
}

static IEnumerable<string> Suits()
{
    yield return "clubs";
    yield return "diamonds";
    yield return "hearts";
    yield return "spades";
}

static IEnumerable<string> Ranks()
{
    yield return "two";
    yield return "three";
    yield return "four";
    yield return "five";
    yield return "six";
    yield return "seven";
    yield return "eight";
    yield return "nine";
    yield return "ten";
    yield return "jack";
    yield return "queen";
    yield return "king";
    yield return "ace";
}
