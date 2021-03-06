# ShmoopySoft Telegram Message Example

A Visual Studio 2019 solution written in C# to demonstrate sending messages to a Telegram Channel using the Telegram BOT Api.

## Getting Started

In order to send messages to Telegram, the following steps must first be completed:

1. Download and install Telegram on your preferred device
2. Create a Telegram public channel
3. Create a Telegram BOT via BotFather
4. Obtain your BOT Api Key
5. Set the bot as administrator in your channel
6. Obtain your channel Chat Id

Obtaining your channel Chat Id can be tricky, but the following article was useful: https://tutorials.botsfloor.com/creating-a-bot-using-the-telegram-bot-api-5d3caed3266d

If you completed the steps above, you can now send a message to your channel by issuing an HTTP GET request to the Telegram BOT API at the following URL:

https://api.telegram.org/bot[BOT_API_KEY]/sendMessage?chat_id=[MY_CHANNEL_CHAT_ID]&text=[MY_MESSAGE_TEXT]

where:

* BOT_API_KEY is the API Key generated by BotFather when you created your bot
* MY_CHANNEL_CHAT_ID is the Chat Id of your channel
* MY_MESSAGE_TEXT is the message you want to send (URL-encoded)

If you are able to send a test message to your Telegram channel, you are ready to continue with the Visual Studio implementation.

### Running

1. Download the solution from our GitHub repository
2. Open the solution in Visual Studio 2019
3. Edit the 'apiToken' and 'chatId' string constants in Program.cs
4. Edit the 'messageText' string variable to set the message text you want to send
5. Click the Start button, or press F5

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

* https://tutorials.botsfloor.com/creating-a-bot-using-the-telegram-bot-api-5d3caed3266d
* https://programmingistheway.wordpress.com/2015/12/03/send-telegram-messages-from-c/
* https://medium.com/@xabaras/sending-a-message-to-a-telegram-channel-the-easy-way-eb0a0b32968
* https://stackoverflow.com/questions/31271355/how-to-use-telegram-api-in-c-sharp-to-send-a-message
