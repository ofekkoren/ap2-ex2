using System;
using ChatWebApp.Models;
public interface IRankService
{
	public List<Rank> GetAll();

	public Rank Get(string Username);

	//todo - submit time should be automatically changed
	public void Edit(string Username, int NumeralRank, string Feedback, string SubmitTime);

	public void Delete(string Username);

	public void Add(string Username, int NumeralRank, string Feedback);

	public float Average();
}
