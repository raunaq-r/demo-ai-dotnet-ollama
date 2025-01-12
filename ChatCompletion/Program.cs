using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;

var builder = Host.CreateApplicationBuilder();

builder.Services.AddChatClient(new OllamaChatClient(new Uri("http://localhost:11434"), "phi3"));

var app = builder.Build();

var chatClient = app.Services.GetRequiredService<IChatClient>();

var chatCompletion = await chatClient.CompleteAsync("What is .NET? Reply in 50 words max.");

Console.WriteLine(chatCompletion.Message.Text);