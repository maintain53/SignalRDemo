<template>
  <b-container fluid>
    <h4 class="p-2 mt-2">REAL TIME DEMO</h4>
    <b-form class="mx-4">
      <label for="fname">First name:</label>
      <b-form-input
        class="my-2"
        v-model="firstName"
        placeholder="Enter First name"
      />
      <label for="lname">Last name:</label>
      <b-form-input
        class="my-2"
        v-model="lastName"
        placeholder="Enter Last name"
      />
      <b-button
        variant="primary"
        @click="sendUserCreationNotification"
        class="mt-3"
        size="sm"
        >Create User</b-button
      >
    </b-form>
    <hr />
    <b-alert
      show
      variant="success"
      class="mt-3"
      dismissible
      v-for="(notification, index) in notifications"
      :key="index"
      >{{notification}}</b-alert
    >
  </b-container>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { HubConnection } from "@/signalRHub/hubConnector.ts";
import User from "@/model/user.ts";

@Component({
  components: {},
})
export default class Page extends Vue {
  firstName = "";
  lastName = "";
  notifications = new Array<string>();


  sendUserCreationNotification() {
    const user: User = { firstName: this.firstName, lastName: this.lastName };
    HubConnection.send("SendNotification", user).catch((err) =>
      console.log(err)
    );
  }

  receiveUserCreationNotification(user: User) {
    const msg = user.firstName +" " + user.lastName + " has been created successfully";
    this.notifications.push(msg);
  }

  created() {
    HubConnection.start();

    HubConnection.on("SendUserCreationNotification", (user: User) => {
      this.$emit("SendUserCreationNotification", user);
    });

    this.$on(
      "SendUserCreationNotification",
      this.receiveUserCreationNotification
    );
  }
}
</script>

<style>
</style>
