using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Geekbrains
{
    public class BotController : BaseController, IOnUpdate, IInitialization
    {
        private readonly int _countBot = 5;
        private HashSet<Bot> GetBotList { get; } = new HashSet<Bot>();

        public void OnStart()
        {
            for (var index = 0; index < _countBot; index++)
            {
                var tempBot = Object.Instantiate(Main.Instance.RefBotPrefab,
                    Patrol.GenericPoint(Main.Instance.Player),
                    Quaternion.identity);

                tempBot.Agent.avoidancePriority = index;
                tempBot.Target = Main.Instance.Player; //todo разных противников
                AddBotToList(tempBot);
            }
        }

        private void AddBotToList(Bot bot)
        {
            if (!GetBotList.Contains(bot))
            {
                GetBotList.Add(bot);
            }
            bot.OnDieChange += RemoveBotToList;
            Main.Instance.TimeRemainingController.Add(bot);
        }

        private void RemoveBotToList(Bot bot)
        {
            if (!GetBotList.Contains(bot))
            {
                return;
            }

            bot.OnDieChange -= RemoveBotToList;
            GetBotList.Remove(bot);
            Main.Instance.TimeRemainingController.Remove(bot);
        }

        public void OnUpdate()
        {
            if (!IsActive)
            {
                return;
            }

            for (var i = 0; i < GetBotList.Count; i++)
            {
                var bot = GetBotList.ElementAt(i);
                bot.Tick();
            }
        }
    }
}
