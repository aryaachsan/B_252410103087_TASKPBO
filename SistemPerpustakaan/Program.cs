using System;

class Item
{
    public string Judul { get; set; }
    public int Tahun { get; set; }

    public Item(string judul, int tahun)
    {
        this.Judul = judul;
        this.Tahun = tahun;
    }
    public virtual void Deskripsi()
    {
        Console.WriteLine($"Item: {Judul} ({Tahun})");
    }
    public void InfoItem()
    {
        Console.WriteLine($"Judul: {Judul}");
        Console.WriteLine($"Tahun Terbit: {Tahun}");
    }
}

class Buku : Item
{
    public string penulis { get; set; }

    public Buku(string judul, int tahun, string penulis) : base(judul, tahun)
    {
        this.penulis = penulis;
    }
    public void CekPenulis()
    {
        Console.WriteLine($"Penulis buku = {penulis}");
    }
    public override void Deskripsi()
    {
        Console.WriteLine($"Judul buku ini {Judul},Tahun terbit ({Tahun}), Penulis {penulis}");
    }

}

class Majalah : Item
{
    public int Edisi { get; set; }

    public Majalah(string judul, int tahun, int edisi) : base(judul, tahun)
    {
        this.Edisi = edisi;
    }
    public void CekEdisi()
    {
        Console.WriteLine($"Edisi majalah = {Edisi}");
    }
    public override void Deskripsi()
    {
        Console.WriteLine($"Majalah ini berjudul {Judul}, Tahun terbit ({Tahun}), Edisi {Edisi}");
    }
}

class Novel : Buku
{
    public Novel(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }

    public void BacaSinopsis()
    {
        Console.WriteLine($"Membaca sinopsis novel {Judul}...");
    }
    public override void Deskripsi()
    {
        Console.WriteLine($"Novel ini berjudul {Judul}, Tahun terbit ({Tahun}), Penulis {penulis}");
    }
}

class Komik : Buku
{
    public Komik(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }

    public void TampilkanIlustrasi()
    {
        Console.WriteLine($"Menampilkan ilustrasi dari komik {Judul}...");
    }
    public override void Deskripsi()
    {
        Console.WriteLine($"Komik ini berjudul {Judul}, Tahun terbit ({Tahun}), Penulis {penulis}");
    }
}

class MajalahAnak : Majalah
{
    public MajalahAnak(string judul, int tahun, int edisi) : base(judul, tahun, edisi) { }

    public void KategoriAnak()
    {
        Console.WriteLine("Kategori: Majalah Anak");
    }
    public override void Deskripsi()
    {
        Console.WriteLine($"Majalah anak ini berjudul {Judul}, Tahun terbit ({Tahun}), Edisi {Edisi}");
    }
}

class MajalahTeknologi : Majalah
{
    public MajalahTeknologi(string judul, int tahun, int edisi) : base(judul, tahun, edisi) { }

    public void TopikTeknologi()
    {
        Console.WriteLine("Topik: Teknologi jadul");
    }
    public override void Deskripsi()
    {
        Console.WriteLine($"Majalah teknologi ini berjudul {Judul}, Tahun terbit ({Tahun}), Edisi {Edisi}");
    }
}

class Perpustakan
{
    private List<Item> koleksi = new List<Item>();

    public void TambahItem(Item item)
    {
        koleksi.Add(item);
    }
    public void DaftarItem()
    {
        foreach (var item in koleksi)
        {
            item.Deskripsi();
        }
    }

}

class Prgram
{
    static void Main()
    {
        // membuat objek perpustakaan
        Perpustakan perpus = new Perpustakan();

        // membuat objek
        Novel novel1 = new Novel("Laskar Pelangi", 2005, "Andrea Hirata");
        Buku book1 = new Buku("Bumi Manusia", 1980, "Pramoedya Ananta Toer");
        Komik komik1 = new Komik("One Piece", 1997, "Eiichiro Oda");
        Majalah majalah1 = new Majalah("Tempo", 1971, 5);
        MajalahAnak majalahAnk1 = new MajalahAnak("Bobo", 2023, 12);
        MajalahTeknologi majalahTekno1 = new MajalahTeknologi("Info Komputer", 1995, 1);

        // menambahkan item ke perpustakaan
        perpus.TambahItem(novel1);
        perpus.TambahItem(book1);
        perpus.TambahItem(komik1);
        perpus.TambahItem(majalah1);
        perpus.TambahItem(majalahAnk1);
        perpus.TambahItem(majalahTekno1);

        // menampilkan daftar item di perpustakaan
        Console.WriteLine("========= Daftar Item =========");
        perpus.DaftarItem();

        // Demonstrasi polimorfisme
        Console.WriteLine("\n========= Demonstrasi Polimorfisme =========");
        Item item = novel1; // Item merujuk ke objek Novel
        item.Deskripsi(); // Memanggil method override di Novel

        // Method khusus
        Console.WriteLine("\n========= Method Khusus =========");
        novel1.BacaSinopsis();
        book1.CekPenulis();
        komik1.TampilkanIlustrasi();
        majalah1.CekEdisi();
        majalahAnk1.KategoriAnak();
        majalahTekno1.TopikTeknologi();

        // Soal no 1
        Console.WriteLine("\n========= Soal no 1 =========");
        Console.WriteLine("NOVEL");
        novel1.Deskripsi();
        Console.WriteLine("");
        Console.WriteLine("MAJALAH");
        majalah1.Deskripsi();
        Console.WriteLine("");

        // Soal no 2
        Console.WriteLine("\n========= Soal no 2 =========");
        Console.WriteLine("NOVEL");
        novel1.BacaSinopsis();
        Console.WriteLine("");

        // Soal no 3
        Console.WriteLine("\n========= Soal no 3 =========");
        Console.WriteLine("NOVEL");
        novel1.Deskripsi();
        Console.WriteLine("");

        // Soal no 4
        Console.WriteLine("\n========= Soal no 4 =========");
        Console.WriteLine("Majalah Teknilogi");
        majalahTekno1.TopikTeknologi();
        Console.WriteLine("");

        // Soal no 5
        Console.WriteLine("\n========= Soal no 5 =========");
        Item item1 = new Komik("Naruto", 1999, "Masashi Kishimoto");
        item1.Deskripsi();


    }
}
