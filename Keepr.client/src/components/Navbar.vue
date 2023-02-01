<template>
  <nav class="navbar navbar-expand-lg navback mb-3 px-3 elevate-5">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <h5>HOME</h5>
    </router-link>
    <div>
      <!-- <button class="btn btn-dark text-success" data-bs-target="#keepForm-modal" data-bs-toggle="modal">CREATE</button> -->
      <div class="dropdown">
        <button v-if="account.id" class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown"
          aria-expanded="false">
          Create
        </button>
        <ul class="dropdown-menu">
          <li><a class="dropdown-item" data-bs-target="#keepForm-modal" data-bs-toggle="modal">Keep</a></li>
          <li><a class="dropdown-item" data-bs-target="#vaultform-modal" data-bs-toggle="modal">Vault</a></li>

        </ul>
      </div>

      <!-- <select class="form-select" aria-label="Create">
        <option selected data-bs-target="#keepForm-modal" data-bs-toggle="modal">
          <a href="">Create A Keep</a>

        </option>
        <option value="2" data-bs-target="#vaultform-modal" data-bs-toggle="modal">
          <a href="">Create A Vault</a>
        </option>
      </select> -->

    </div>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav me-auto">
        <li>
        </li>
      </ul>
      <!-- LOGIN COMPONENT HERE -->
      <Login />
    </div>
  </nav>
</template>

<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState.js";
import KeepForm from "./KeepForm.vue";
import Login from './Login.vue'
import VaultForm from "./VaultForm.vue";
export default {
  setup() {
    return {
      account: computed(() => AppState.account)

    }
  },
  components: { Login, KeepForm, VaultForm }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navback {
  background-color: #F2E1D9;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}
</style>
