<template>
  <div class="profile">
    <div>
      <div>
        <div v-if="creator">
          <img :src="creator?.picture" alt="profile-cover-img">
        </div>
        <h3 class="text-secondary mb-md-0">{{ creator?.name }}</h3>
        <h1><a>Vaults {{ vaults.length }}</a> :
          <a>Keeps {{ keeps.length }}</a>
        </h1>
      </div>
    </div>
    <div class="masonry-with-column">
      <h2>Vaults</h2>
      <div class="" v-for="v in vaults">
        <VaultCard :vault="v" />
      </div>
    </div>
    <div class="masonry-with-columns">
      <h2>Keeps</h2>
      <div v-for="k in keeps">
        <KeepsCard :keep="k" />
      </div>
    </div>
  </div>


</template>

<script>
import { computed } from "@vue/reactivity";
import { useRoute } from "vue-router";
import { AppState } from "../AppState.js";
import KeepsCard from "../components/KeepsCard.vue";
import VaultCard from "../components/VaultCard.vue";
import { profileService } from "../services/ProfileService.js";
import { keepsService } from "../services/KeepsService.js";
import Pop from "../utils/Pop.js";
import { vaultService } from "../services/VaultsService.js";
import { onAuthLoaded } from "@bcwdev/auth0provider-client";

export default {
  setup() {
    const route = useRoute();



    async function GetProfileById() {
      try {
        await profileService.GetProfileId(route?.params?.profileId);
      }
      catch (error) {
        Pop.error(error["getting profiles"]);
      }
    }


    async function GetKeepsByProfile() {
      try {
        await keepsService.GetKeepsByProfile(route?.params?.profileId);
      }
      catch (error) {
        Pop.error(error["getting keeps in profile"]);
      }
    }

    async function GetVaultsByProfile() {
      try {
        await vaultService.GetVaultsByProfile(route?.params?.profileId);
      }
      catch (error) {
        Pop.error(error["getting vaults in profile"]);
      }
    }




    onAuthLoaded(() => {
      GetProfileById();
      GetKeepsByProfile();
      GetVaultsByProfile();
    });
    return {
      creator: computed(() => AppState.ActiveProfile),
      keeps: computed(() => AppState.profileKeep),
      vaults: computed(() => AppState.profileVault),
      activeVault: computed(() => AppState.activeVault)
    };
  },
  components: { VaultCard }
}
</script>
<style scoped lang="scss">
.masonry-with-columns {
  columns: 4;


}

.masonry-with-column {
  columns: 3;


}

.forcedImg {
  height: 400px;
  width: auto;
  object-fit: cover;
}
</style>