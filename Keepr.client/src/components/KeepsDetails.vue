<template>
  <!-- <div v-if="keep">
    <div class="card mb-3" style="width: 45rem;">
      <div class="row g-0">
        <div class="col-md-4">
          <img :src="keep.img" class="img-fluid rounded-start forcedImg" alt="KeepImg">
        </div>
        <div class="col-md-8">
          <div class="card-header">
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            <span> <i class="mdi mdi-mdieye">views{{ keep.views }}</i> : <i class="mdi mdi-mdiTemperatureKelvin">kept{{
              keep.kept
            }}</i></span>
          </div>
          <div class="card-body">
            <h5 class="card-title">{{ keep.name }}</h5>
            <p class="card-text">{{ keep.description }}</p>
          </div> -->
  <!-- DROPDOWN FOR VAULTS -->
  <!-- <div class="card-footer">

            <div class="dropdown" v-if="account.id">
              <button class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown"
                aria-expanded="false">
                MyVaults
              </button>
              <ul class="dropdown-menu">
                <li v-for="v in myVaults" :key="v?.id">
                  <a class="dropdown-item" href="#" @click="AddKeeptoVault(v)" :vault="v">{{
                    v?.name
                  }}</a>
                </li>
              </ul>
            </div> -->
  <!-- CREATOR PROFILE -->
  <!-- <p class="text-secondary mb-md-0">@{{ keep.creator.name.split("@")[0] }}</p>
            <router-link :to="{ name: 'Profile', params: { profileId: keep.creator.id } }"
              class="btn text-success lighten-30 selectable text-uppercase">
              <img :src="keep.creator.picture" alt="creator profile picture" :title="keep.creator.name + 'picture'"
                class="rounded-circle ms-2 mb-1" height="40">
            </router-link>

            <div v-if="keep.creatorId == account.id">
              <i class="mdi mdi-delete" @click="deleteKeep()"></i>

              <div><button class="btn-dark btn" @click="deleteVaultKeep()" v-if="name">DELETE VAULTKEEP</button>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div>
    </div>
  </div> -->

  <div class="container-fluid postiion relative" v-if="keep">
    <div class="row">
      <div class="col-md-6 col-lg-12 p-0">
        <div class="img rounded-start">
        </div>
        <div class="col-md-6 col-lg-12 d-flex justify-content-between flex-column">
          <div class="d-flex gap-2 justify-content-center mt-3">
            <div class="d-flex gap-2">
              <i class="mdi mdi-eye mx-1 fs-3 no-select" title="Views count"></i>
              <span class="align-self-center">{{ keep?.views }}</span>
            </div>
            <div class="d-flex gap-2 align-items-start">
              <i class="mdi mdi-alpha-k-box-outline fs-3 no-select"
                title="Amount of times this keep has been vaulted"></i>
              <span class="align-self-center">{{ keep?.kept }}</span>
            </div>
            <div class="align-self-center icon me-1">
              <i class="mdi mdi-delete selectable fs-4 rounded" v-if="keep.creatorId == account.id" title="delete keep"
                @click="deleteKeep(keep)"></i>
            </div>
          </div>
        </div>
        <div>
          <h1 class="text-center">{{ keep?.name }}</h1>
          <img :src="keep.img" alt="Image for the keep" class="forcedImg">
          <p class="px-md-5 px-sm-2 d-flex">{{ keep?.description }}</p>
        </div>
        <div class="d-flex mb-2" :class="account ? 'justify-content-between' : ' justify-content-end'">
          <div v-if="account">
            <div class="d-flex gap-2" v-if="!routeVault || !vaultOwner"></div>
            <div class="dropdown" v-if="account.id">
              <button class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown"
                aria-expanded="false">
                MyVaults
              </button>
              <ul class="dropdown-menu">
                <li v-for="v in myVaults" :key="v?.id">
                  <a class="dropdown-item" href="#" @click="AddKeeptoVault(v)" :vault="v">{{
                    v?.name
                  }}</a>
                </li>
              </ul>
            </div>
            <router-link :to="{ name: 'Profile', params: { profileId: keep.creator.id } }">
              <div class="d-flex align-items-center gap-3 ms-2">
                <img :src="keep?.creator.picture" :alt="keep?.creator.name" :title="keep?.creator.name" height="50"
                  class="rounded-circle shadow-2 ">
              </div>
            </router-link>
          </div>
        </div>
      </div>
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
import { keepsService } from "../services/KeepsService.js";
import { useRoute } from "vue-router";
import { propsToAttrMap } from "@vue/shared";



export default {
  props: {
    keeps: { type: Keep, required: true }
  },

  setup(props) {
    const route = useRoute();

    watchEffect(() => {
      AppState.activeKeep;
      AppState.ActiveProfile;
      AppState.vaults;
    })
    return {
      routeVault: computed(() => route.name == "Vault"),
      vaultOwner: computed(() => AppState.account?.id == props.keep.creatorId),
      keep: computed(() => AppState.activeKeep),
      creator: computed(() => AppState.ActiveProfile),
      vaults: computed(() => AppState.profileVault),
      profile: computed(() => AppState.profile),
      account: computed(() => AppState.account),
      myVaults: computed(() => AppState.myVaults),
      name: computed(() => route.name == 'Vault'),


      async SetActiveProfile() {
        try {
          profileService.SetActiveProfile(route.params.vaultId)
        } catch (error) {
          Pop.error(error);
        }
      },
      async deleteKeep() {
        try {
          if (await Pop.confirm("do you want to delete this keep?")) {
            await keepsService.deleteKeep(AppState.activeKeep.id)
            Modal.getOrCreateInstance('#keeps-modal').hide()
            Pop.success("Its Been Deleted")
          }
        } catch (error) {
          Pop.error(error)
        }
      },



      async deleteVaultKeep() {
        try {
          if (await Pop.confirm("you sure?")) {
            await vaultKeepsService.deleteVaultKeep(AppState.activeKeep.vaultKeepId)
            Modal.getOrCreateInstance('#keeps-modal').hide()
            Pop.success("its been removed")
          }
        } catch (error) {
          Pop.error(error)
        }
      },


      async AddKeeptoVault(v) {
        try {
          if (!AppState.account.id) {
            return AuthService.loginWithRedirect
          }
          const addkeep = {
            vaultId: v.id,
            keepId: AppState.activeKeep.id,
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