<template>
  <div class="VaultCard">

    <div class="card text-dark  " v-if="vault">
      <img class="card-img" :src="vault.img" alt="Card-Image" />
      <div class="card-img-overlay">
        <h5 class="card-title">{{ vault.name }}</h5>
      </div>
    </div>
  </div>
</template>


<script>
import { Vault } from "../models/Vault.js";

export default {
  props: {
    vault: { type: Vault, required: true }
  },

  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>

</style>