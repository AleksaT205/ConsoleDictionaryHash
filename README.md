# 📚 MySimpleDictionary – Testiranje i Benchmark Hash Tabela

Ovo je **C# konzolna aplikacija** za demonstraciju i testiranje implementacije rečnika (*dictionary*) korišćenjem **hash tabela**.  
Sadrži sopstvenu klasu `MySimpleDictionary<TKey, TValue>` i jednostavan **benchmark** za merenje performansi.

## ✨ Karakteristike

- Implementacija generičkog rečnika (`Dictionary`) sa:
  - Dodavanjem elemenata (`Add`)
  - Uklanjanjem po ključu (`Remove`)
  - Dohvatanjem vrednosti (`this[key]`)
  - Proverom postojanja ključa (`ContainsKey`)
  - Proverom postojanja vrednosti (`ContainsValue`)
  - Dohvatanjem svih ključeva (`Keys`) i vrednosti (`Values`)
  - Brisanjem svih elemenata (`Clear`)
- Podrška za enumeraciju (`IEnumerable<KeyValuePair<TKey, TValue>>`)
- Jednostavan **benchmark** za merenje:
  - Vremena dodavanja 100.000 elemenata
  - Vremena provere postojanja ključa
  - Vremena uklanjanja ključa

## 📂 Struktura projekta

MySimpleDictionary/
│
├── Program.cs # Ulazna tačka aplikacije
├── MySimpleDictionary.cs # Implementacija rečnika
├── Benchmark.cs # Klasa za test performansi
└── README.md # Ovaj fajl


## 🚀 Kako pokrenuti

1. **Kloniraj repozitorijum**
   ```bash
   git clone https://github.com/korisnik/MySimpleDictionary.git
   cd MySimpleDictionary
   dotnet run ili još bolje run iz VS
