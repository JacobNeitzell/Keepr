import { Keep } from "./Keep.js"
import { Vault } from "./Vault.js"

export class VaultKeep {
  constructor(data) {
    this.id = data.id
    this.creatorId = data.creatorId
    this.vaultId = new Vault(data.vaultId)
    this.keepId = new Keep(data.keepId)
  }
}