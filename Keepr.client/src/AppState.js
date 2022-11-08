import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},
  /** @type {import('./models/Keep.js').Keep[]} */
  keep: [],
  /** @type {import('./models/Keep.js').Keep | null} */
  views: [],
  kept: [],
  /** @type {import('./models/Vault.js').Vault[]} */
  vault: [],
  /** @type {import('./models/Vault.js').Vault | null} */
  isprivate: null,
  activeVault: null,
  /** @type {import('./models/VaultKeep.js').VaultKeep[]} */
  vaultkeep: [],
})
