/*
 * MIT License
 * 
 * Copyright(c) 2020 ShmoopySoft
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and 
 * associated documentation files (the "Software"), to deal in the Software without restriction, including 
 * without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell 
 * copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the 
 * following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all copies or substantial 
 * portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT 
 * LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO 
 * EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER 
 * IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE 
 * USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Net;
using System.IO;

namespace ShmoopySoft_Telegram_Message_Example
{
    class Program
    {
        // Insert your Telegram BOT Api Token and Chat Id values here.
        protected const string apiToken = "<<<!!! INSERT YOUR TELEGRAM BOT API TOKEN HERE !!!>>>";
        protected const string chatId = "<<<!!! INSERT YOUR TELEGRAM CHANNEL CHAT ID HERE !!!>>>";

        public static void Main(string[] args)
        {
            // String variables to store the Telegram URL and message text (url encoded).
            string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
            string messageText = "Telegram message test from Visual Studio!";

            // Set the Telegram URL.
            urlString = String.Format(urlString, apiToken, chatId, messageText);

            try
            {
                // Create a web request using the formatted Telegram URL.
                WebRequest request = WebRequest.Create(urlString);

                // Get the response.  
                WebResponse response = request.GetResponse();

                // Get the status.  
                string responseStatus = ((HttpWebResponse)response).StatusDescription;

                // Check the status.
                if (responseStatus == "OK")
                {
                    // Get the stream containing content returned by the server.  
                    // The using block ensures the stream is automatically closed.
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        // Open the stream using a StreamReader for easy access.  
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                            // Read the content.  
                            string responseFromServer = reader.ReadToEnd();

                            // Check the content.
                            if (responseFromServer.Contains("\"ok\":true"))
                            {
                                // Display a confirmation.
                                Console.WriteLine("Message text was successfully sent to Telegram :-)");
                            }
                            else
                            {
                                // Display an error.
                                Console.WriteLine("Failed to send the message text to Telegram :-(");
                            }

                            // Display the content.  
                            Console.Write(Environment.NewLine);
                            Console.WriteLine(responseFromServer);
                        }
                    }
                }
                else
                {
                    // Display an error.
                    Console.WriteLine("Failed to send the message text to Telegram :-(");
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("Response status: " + responseStatus);
                }

                // Close the response.  
                response.Close();

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                // Display an error.
                Console.WriteLine("Failed to send the message text to Telegram :-(");
                Console.Write(Environment.NewLine);
                Console.WriteLine(ex.ToString());

                Console.ReadKey();
            }
        }
    }
}
