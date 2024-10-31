namespace TrainModule2_New.Services
{
    public static class TokenBlackList
    {
        static HashSet<String> blackList = new HashSet<String>();
        public static void addBlackList(String token)
        {
            blackList.Add(token);
        }
        public static bool checkTokenInBlacklist(String token)
        {
            return blackList.Contains(token);
        }
    }
}
