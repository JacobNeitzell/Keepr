<template>
  <div class="VaultPage">
    <div>0</div>
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

import { computed } from "@vue/reactivity";
import { watchEffect } from "vue";
import { useRoute } from "vue-router";
import { AppState } from "../AppState.js";
import KeepsCard from "../components/KeepsCard.vue";
import { Vault } from "../models/Vault.js";
import { vaultKeepsService } from "../services/VaultKeepsService.js";
import { vaultService } from "../services/VaultsService.js";
import Pop from "../utils/Pop.js";

export default {
  props: {
    Vault: {
      type: Vault,
      required: true
    }
  },
  setup() {
    const route = useRoute();

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
    async function GetVaultKeeps() {
      try {
        await vaultKeepsService.GetVaultKeeps(route?.params?.vaultId)
      } catch (error) {
        Pop.error(error)
      }
    }

    watchEffect(() => {
      AppState.activeVault;
    })

    onMounted(() => {
      AppState.activeVault; getVault();
      GetVaultKeeps();
    });
    return {
      keep: computed(() => AppState.keep),
      vaultkeep: computed(() => AppState.vaultkeep)

    };
  },
  components: { KeepsCard }
}
</script>


<style lang="scss" scoped>

</style>