<template>
  <div class="VaultForm">
    <form @submit.prevent="CreateVault()">
      <div class="modal-body">
        <div class="form-floating mb-3">
          <input v-model="editable.name" required type="text" class="form-control" id="vaultName" placeholder="Name...">
          <label for="VaultName">Vault Name</label>
        </div>
        <div class="form-floating mb-3">
          <textarea v-model="editable.description" required type="text" class="form-control" id="vaultDescription"
            placeholder="Description...">
                </textarea>
          <label for="floatingDescription">Description</label>
        </div>
        <div class="form-floating mb-3">
          <input v-model="editable.img" required type="url" class="form-control" id="vaultImg" placeholder="Image...">
          <label for="VaultImg">Vault Image</label>
        </div>
        <div class="form-floating mb-3">
          <input v-model="editable.isPrivate" type="checkbox" class="form-check-input mb-3" id="vaultisPrivate"
            placeholder="isPrivate">
          <label for="VaultImg" class="">IsPrivate?</label>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
          <button type="submit" class="btn btn-primary">Save changes</button>
        </div>
      </div>
    </form>

  </div>
</template>


<script>
import { Modal } from "bootstrap";
import { ref } from "vue";
import { vaultService } from "../services/VaultsService.js";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";

export default {
  setup() {
    const editable = ref({})
    return {
      editable,
      async CreateVault() {
        try {
          logger.log(editable.value)
          await vaultService.CreateVault(editable.value)
          editable.value = {};
          Modal.getOrCreateInstance('#vaultform-modal').hide()
        } catch (error) {
          Pop.error(error["creating vault"])
        }
      }


    }
  }
}
</script>


<style lang="scss" scoped>

</style>