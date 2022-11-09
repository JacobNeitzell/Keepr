<template>
  <div class="VaultPage">
    <div>14 keeps</div>
    <div class="card text-dark  " v-if="vault">
      <img class="card-img forcedImg" :src="vault.img" alt="Card-Image" />
      <div class="card-img-overlay">
        <h5 class="card-title">{{ vault.name }}</h5>
        <p class="card-text">{{ vault.creator.imgUrl }}</p>
        <KeepsCard :keep="k" :key="k.id" />
      </div>
    </div>

  </div>
</template>


<script>

import { AppState } from "../AppState.js";
import KeepsCard from "../components/KeepsCard.vue";
import { Vault } from "../models/Vault.js";
import { vaultService } from "../services/VaultsService.js";
import Pop from "../utils/Pop.js";

export default {
  props: {
    vault: {
      type: Vault,
      required: true
    }
  },
  setup() {
    async function getVault() {
      try {
        if (AppState.activeVault) {
          let vaultId = AppState.activeVault.id;
          await vaultService.getVault(vaultId);
        }
      }
      catch (error) {
        Pop.error(error);
      }
    }
    onMounted(() => { AppState.activeVault; getVault(); });
    return {};
  },
  components: { KeepsCard }
}
</script>


<style lang="scss" scoped>

</style>