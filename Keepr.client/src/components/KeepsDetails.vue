<template>
  <div v-if="keep">
    <div class="card mb-3" style="width: 45rem;">
      <div class="row g-0">
        <div class="col-md-4">
          <img :src="keep.img" class="img-fluid rounded-start forcedImg" alt="KeepImg">
        </div>
        <div class="col-md-8">
          <div class="card-header">
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            <span> {{ keep.views }} {{ keep.kept }}</span>
          </div>
          <div class="card-body">
            <h5 class="card-title">{{ keep.name }}</h5>
            <p class="card-text">{{ keep.description }}</p>
          </div>
          <!-- DROPDOWN FOR VAULTS -->
          <div class="card-footer">
            <region>
              <div class="dropdown" v-if="account.id">
                <button class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown"
                  aria-expanded="false">
                  MyVaults
                </button>
                <ul class="dropdown-menu">
                  <li v-for="v in vaults" :key="v?.id">
                    <a class="dropdown-item" href="#" @click="AddKeeptoVault()" :vault="v">{{
                        v?.name
                    }}</a>
                  </li>
                </ul>
              </div>
            </region>
            <!-- CREATOR PROFILE -->
            <region>
              <p class="text-secondary mb-md-0">@{{ keep?.creator.name.split("@")[0] }}</p>
              <router-link :to="{ name: 'Profile', params: { profileId: keep.creator.id } }"
                class="btn text-success lighten-30 selectable text-uppercase">
                <img :src="keep?.creator.picture" alt="creator profile picture" :title="keep.creator.name + 'picture'"
                  class="rounded-circle ms-2 mb-1" height="40">
              </router-link>
            </region>
          </div>
        </div>
      </div>
    </div>
    <div>
    </div>
  </div>








</template>


<script>
import { computed } from "@vue/reactivity";
import { watchEffect } from "vue";
import { AppState } from "../AppState.js";
import { Keep } from "../models/Keep.js";
import { vaultKeepsService } from "../services/VaultKeepsService.js";
import Pop from "../utils/Pop.js";
import { Modal } from 'bootstrap';
import { profileService } from "../services/ProfileService.js";
import { AuthService } from "../services/AuthService.js";


export default {

  setup() {

    watchEffect(() => {
      AppState.activeKeep;
      AppState.ActiveProfile;
      AppState.vaults;
    })
    return {
      keep: computed(() => AppState.activeKeep),
      creator: computed(() => AppState.ActiveProfile),
      vaults: computed(() => AppState.profileVault),
      profile: computed(() => AppState.profile),
      account: computed(() => AppState.account),





      async SetActiveProfile() {
        try {
          profileService.SetActiveProfile(route.params.vaultId)
        } catch (error) {
          Pop.error(error);
        }
      },

      async AddKeeptoVault() {
        try {
          if (!AppState.account.id) {
            return AuthService.loginWithRedirect
          }
          const addkeep = {
            vaultId: AppState.vault.id,
            keepId: AppState.activeVault,
          }
          await vaultKeepsService.AddKeeptoVault(addkeep)
          Pop.success("Keep Has Been Added")
        } catch (error) {
          Pop.error(error);
        }
      }




    }
  }
}
</script>


<style lang="scss" scoped>
.forcedImg {
  height: 300px;
  width: auto;
  object-fit: cover;
}
</style>