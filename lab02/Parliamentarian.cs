namespace ParliamentApp;

public class Parliamentarian
{
    public readonly int Id;
    private bool _isVotingActive;
    private bool _alreadyVoted;

    public Parliamentarian(int id, Parliament parliament)
    {
        Id = id;
        _isVotingActive = false;
        _alreadyVoted = false;
        parliament.CollectingVotes += VotingIsActive;
        parliament.StopCollectingVotes += VotingIsClosed;
    }

    public bool Vote()
    {
        if (_isVotingActive && !_alreadyVoted)
        {
            _alreadyVoted = true;
            return new Random().Next() % 2 == 0;
        }

        if (_alreadyVoted)
            throw new Exception($"The parliamentarian with id {Id} has already voted on the given topic!");

        throw new Exception($"Parliamentarian with id {Id} tried to vote, but voting is not active.");
    }

    private void VotingIsActive(object? o, EventArgs e)
    {
        _isVotingActive = true;
    }

    private void VotingIsClosed(object? o, EventArgs e)
    {
        _alreadyVoted = false;
        _isVotingActive = false;
    }
}