public abstract class Command {

    public Player reciever;

    public Command(Player player) {
        reciever = player;
    }

    public abstract void Execute();
    

    public void ChangeReciever(Player player){
        reciever = player;
    }
}