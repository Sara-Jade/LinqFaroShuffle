// See https://aka.ms/new-console-template for more information
using LinqFaroShuffle;

Console.WriteLine("Hello, World!");

var startingDeck = from s in Suits()
           from r in Ranks()
           select new {Suits = s, Ranks = r };

Console.WriteLine("\nStarting deck:");
foreach (var card in startingDeck)
{
    Console.WriteLine(card);
}

var topHalf = startingDeck.Take(startingDeck.Count() / 2);
var bottomHalf = startingDeck.Skip(startingDeck.Count() / 2);
var shuffledDeck = topHalf.InterleaveCards(bottomHalf);

Console.WriteLine("\nFaro shuffled deck:");
foreach (var card in shuffledDeck)
{
    Console.WriteLine(card);
}

Console.WriteLine("\nQ: How many faro shuffles until we reach our original deck? Include our first shuffle.");

int shuffleCounter = 1;
while (!startingDeck.AreSequencesEqual(shuffledDeck) && shuffleCounter < startingDeck.Count() * 10)
{
    topHalf = shuffledDeck.Take(shuffledDeck.Count() / 2);
    bottomHalf = shuffledDeck.Skip(shuffledDeck.Count() / 2);
    shuffledDeck = topHalf.InterleaveCards(bottomHalf);

    ++shuffleCounter;
}

if (shuffleCounter < startingDeck.Count() * 10)
{
    Console.WriteLine($"A: {shuffleCounter}");
}
else
{
    Console.WriteLine($"A: We tried and tried and couldn't get equivalent decks, even after {shuffleCounter} shuffles.");
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
