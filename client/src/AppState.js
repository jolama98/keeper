import { reactive } from 'vue'
import { Keep } from './models/Keep.js'
import { Vault } from './models/Vault.js'
import { VaultKeepVault, VaultProfile } from './models/VaultKeep.js'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  /**@type {import('@bcwdev/auth0provider-client').Identity} */
  identity: null,
  /** @type {import('./models/Account.js').Account} user info from the database*/
  account: null,
  /** @type {Keep[]} */
  keeps: [],
  /** @type {Keep[]} */
  setActiveKeep: [],
  /** @type {Vault[]}  */
  vaults: [],
  /** @type {Vault}  */
  activeVaults: null,
  /** @type {VaultKeepVault[]} */
  accountVaults: [],
  /** @type {VaultProfile[]} */
  vaultProfile: []

})

