// See https://aka.ms/new-console-template for more information

using PrincessChoicer.model;
using PrincessChoicer.utils;

var challengerList = ContentGenerator.GenerateChallengerList();
var hall = new Hall(challengerList);
var friend = new Friend();
Console.WriteLine(Constants.Delimiter);
var princess = new Princess(friend, hall);
princess.TellWhoIsHusband();