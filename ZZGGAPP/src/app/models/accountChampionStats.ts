export class AccountChampionStats{
    public championId: number | undefined;
    public championLevel : number | undefined;
    public championPoints : number | undefined;
    public lastPlayTime : number | undefined;
    public championPointsSinceLastLevel : number | undefined;
    public championPointsUntilNextLevel : number | undefined;
    public chestGranted : boolean | undefined;
    public tokensEarned  : number | undefined;
    public summonerId : string | null = "";
}
