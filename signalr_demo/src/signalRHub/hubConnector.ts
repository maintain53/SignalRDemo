import * as signalR from "@microsoft/signalr";

export const HubConnection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:44352/notification")
    .build();
