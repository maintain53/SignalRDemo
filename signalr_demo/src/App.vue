<template>
  <div id="app">
    <page />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import Page from "@/components/Page.vue";

@Component({
  components: {
    page: Page,
  },
})
export default class App extends Vue {}
</script>

<style>
</style>
