import { AppState } from "../AppState.js"
import { Vault } from "../models/Vault.js"
import { router } from "../router.js";
import { api } from "./AxiosService.js"

class VaultsService {
  async getVault(vaultId) {
    const res = await api.get(`api/vaults/${vaultId}`)
    AppState.activeVault = new Vault(res.data);

  }


  async GetVaultsByProfile(profileId) {
    const res = await api.get('api/profiles/' + profileId + '/vaults')
    AppState.profileVault = res.data.map((v) => new Vault(v))

  }

  async removeVault(id) {
    await api.delete('api/vaults/' + id)
    AppState.activeVault = null
    AppState.myVaults = AppState.myVaults.filter((v) => v.id != id)
    router.push({ name: 'Home' })

  }

  async setActiveVault(vault) {
    AppState.activeVault = vault;
    const res = await api.get(`api/vaults/${vault.id}`)
  }

  async CreateVault(data) {
    const res = await api.post("api/vaults", data)
    AppState.vault.push(res.data)
  }

}
export const vaultService = new VaultsService()