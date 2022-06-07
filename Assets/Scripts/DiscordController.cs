using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;
using UnityEngine.SceneManagement;

public class DiscordController : MonoBehaviour
{
    Discord.Discord discord;

    // Start is called before the first frame update
    void Start()
    {
        discord = new Discord.Discord(983429038897004585, (System.UInt64)Discord.CreateFlags.Default);
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity();

        switch (SceneManager.GetActiveScene().name)
        {
            case "Jogo1_Mobile":
                activity = new Discord.Activity
                {
                    Details = "Sailing the seas.",
                    State = "Looting the place."
                };

                activityManager.UpdateActivity(activity, (res) =>
                {
                    if (res == Discord.Result.Ok)
                    {
                        Debug.Log("Status set on Main game!");
                    }
                    else
                    {
                        Debug.LogError("Status failed on Main game!");
                    }
                });
                break;
            case "Homebay_New_Mobile":
                activity = new Discord.Activity
                {
                    Details = "Ruling over the city.",
                    State = "Whipping all the rascals."
                };

                activityManager.UpdateActivity(activity, (res) =>
                {
                    if (res == Discord.Result.Ok)
                    {
                        Debug.Log("Status set on Homebay!");
                    }
                    else
                    {
                        Debug.LogError("Status failed on Homebay!");
                    }
                });
                break;
            case "ChangeBoat_Mobile":
                activity = new Discord.Activity
                {
                    Details = "Prittyfying their boat.",
                    State = "The seashells stay!"
                };

                activityManager.UpdateActivity(activity, (res) =>
                {
                    if (res == Discord.Result.Ok)
                    {
                        Debug.Log("Status set on Customise!");
                    }
                    else
                    {
                        Debug.LogError("Status failed on Customise!");
                    }
                });
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        discord.RunCallbacks();
    }
}
