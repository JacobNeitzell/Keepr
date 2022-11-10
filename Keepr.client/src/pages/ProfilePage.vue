<template>
  <div class="profile">
    <div class="container-fluid">
      <div class="row">
        <div class="col-12" v-if="keep">
          <img :src="keep?.creator.imgurl" alt="profile-cover-img">
        </div>
        <h3 class="text-secondary mb-md-0">@{{ keep?.creator.name.split("@")[0] }}</h3>
      </div>
      <div class="row">
        <div class="col-md-3 col-lg-12">
          <h2>Vaults</h2>
          <VaultCard />
        </div>
      </div>
      <div class="row">
        <div class="col-md-6 keep" v-for="k in profilekeep">
          <h2>Keeps</h2>
          <KeepsCard :profilekeep="k" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { onMounted } from "vue";
import { useRoute } from "vue-router";
import { AppState } from "../AppState.js";
import KeepsCard from "../components/KeepsCard.vue";
import VaultCard from "../components/VaultCard.vue";
import { Account } from "../models/Account";
import { Keep } from "../models/Keep.js";
import { api } from "../services/AxiosService.js";
import { profileService } from "../services/ProfileService.js";
import { keepsService } from "../services/KeepsService.js";
import Pop from "../utils/Pop.js";

export default {

  setup() {
    const route = useRoute();



    async function GetProfileById() {
      try {
        await profileService.GetProfilebyId(route.params.profileId)
      } catch (error) {
        Pop.error(error["getting profiles"])
      }
    }
    async function GetKeepsByProfile() {
      try {
        await keepsService.GetKeepsByProfile(route.params.profileId)
      } catch (error) {
        Pop.error(error["getting keeps in profile"])
      }
    }

    onMounted(() => {
      GetProfileById();
      GetKeepsByProfile();
    })
    return {
      creator: computed(() => AppState.account.id == AppState.keep.id),
      keep: computed(() => AppState.keep.id),
      profilekeep: computed(() => AppState.ProfileKeep == AppState.keep.id)
    };
  },
}
</script>
