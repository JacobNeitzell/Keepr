<template>
  <div class="VaultPage">
    <div>
      <h1>Keeps={{ vaultkeeps.length }}</h1>
    </div>
    <div class="card text-dark  vault" v-if="vault">
      <img class="card-img forcedImg" :src="vault.img" alt="Card-Image" />
      <div class="card-img-overlay">
        <h5 class="card-title">{{ vault.name }}</h5>
        <p class="card-text">{{ vault.creator.imgUrl }}</p>
        <button class="btn-dark btn" @click="deleteVault()">DELETE</button>
      </div>
      <div class="masonry-with-columns" v-for="k in vaultkeeps">
        <KeepsCard :keep="k" :key="k.id" />
      </div>
    </div>

  </div>
</template>


<script>

import { computed } from "@vue/reactivity";
import { onMounted } from "vue";
import { useRoute, useRouter } from "vue-router";
import { AppState } from "../AppState.js";
import KeepsCard from "../components/KeepsCard.vue";
import { Vault } from "../models/Vault.js";
import { router } from "../router.js";
import { vaultKeepsService } from "../services/VaultKeepsService.js";
import { vaultService } from "../services/VaultsService.js";
import Pop from "../utils/Pop.js";

export default {

  setup() {
    const route = useRoute();
    const router = useRouter();




    async function GetVault() {
      try {
        AppState.activeVault = null
        await vaultService.getVault(route.params.vaultId);
      }
      catch (error) {
        router.push({ name: 'Home' })
      }
    }
    async function GetVaultKeeps() {
      try {
        await vaultKeepsService.GetVaultKeeps(route?.params?.vaultId)
      } catch (error) {
        Pop.error(error)
      }
    }
    onMounted(() => {
      GetVault();
      GetVaultKeeps();
    });
    return {
      vaultkeeps: computed(() => AppState.vaultkeeps),
      vault: computed(() => AppState.activeVault),
      keep: computed(() => AppState.keep),

      async deleteVault() {
        try {
          if (await Pop.confirm("are you sure you want to delete?"))
            await vaultService.removeVault(this.vault.id)
        } catch (error) {
          Pop.error(error)
        }
      }



    };
  },
  components: { KeepsCard }
}
</script>


<style lang="scss" scoped>
.vault {
  width: 759px;
  height: 338px;
}

.masonry-with-columns {
  columns: 2;


}
</style>