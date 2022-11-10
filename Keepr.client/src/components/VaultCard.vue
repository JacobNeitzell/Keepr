<template>
  <div class="VaultCard">
    <div class="card text-dark" v-if="vault">
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
.card:hover {
  filter: brightness(90%);
  transition: all 0.5s ease;
  box-shadow: rgba(223, 12, 132, 0.4) 5px 5px, rgba(88, 3, 101, 0.3) 10px 10px,
    rgba(175, 8, 138, 0.2) 15px 15px, rgba(60, 45, 6, 0.1) 20px 20px;
}

.forcedImg {
  height: 131px;
  width: 195px;
  object-fit: cover;
}
</style>