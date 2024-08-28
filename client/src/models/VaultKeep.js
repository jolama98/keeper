import { Account } from "./Account.js";
import { Vault } from "./Vault.js";

export class VaultKeep {
  constructor(data) {
    this.id = data.id;
    this.vaultId = data.vaultId;
    this.keepId = data.keepId;
  }
}

export class VaultProfile extends VaultKeep {
  constructor(data) {
    super(data)
    this.profile = new Account(data.profile)
  }
}

export class VaultKeepVault extends VaultKeep {
  constructor(data) {
    super(data)
    this.vault = new Vault(data.album)
  }
}
