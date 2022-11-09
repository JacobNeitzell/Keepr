<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <ModalComponent id="keeps-modal">
    <KeepsDetails />
  </ModalComponent>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import KeepsDetails from "./components/KeepsDetails.vue"
import ModalComponent from "./components/ModalComponent.vue"
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, ModalComponent, KeepsDetails }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

main {
  background-color: #FEF6F0;
}

body {
  background-color: #FEF6F0;
  margin: 0;
  padding: 1rem;
}
</style>
