﻿using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;

var builder = Host.CreateApplicationBuilder();

builder.Services.AddChatClient(new OllamaChatClient(new Uri("http://localhost:11434"), "phi3"));

var app = builder.Build();

var chatClient = app.Services.GetRequiredService<IChatClient>();

var chatHistory = new List<ChatMessage>();

while (true)
{
   Console.WriteLine("Enter your prompt:");
   var userPrompt = Console.ReadLine();
   chatHistory.Add(new ChatMessage(ChatRole.User, userPrompt));

   Console.WriteLine("Response from AI:");
   var chatResponse = "";
   await foreach (var item in chatClient.CompleteStreamingAsync(chatHistory))
   {
       // We're streaming the response, so we get each message as it arrives
       Console.Write(item.Text);
       chatResponse += item.Text;
   }
   chatHistory.Add(new ChatMessage(ChatRole.Assistant, chatResponse));
   Console.WriteLine();
}
